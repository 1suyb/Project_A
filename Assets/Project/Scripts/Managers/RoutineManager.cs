using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoutineManager : Singleton<RoutineManager>
{
    private Dictionary<string, IEnumerator> _coroutineDic = new Dictionary<string, IEnumerator>();
    private Dictionary<int, Action<int>> _turnRoutine = new Dictionary<int, Action<int>>();

    private void Start()
    {
        EventRouter.Subscribe<TurnEvent>(InvokeTurnRoutine);
    }
    
    public void InvokeTurnRoutine(TurnEvent turnEvent)
    {
        foreach (var routine in _turnRoutine)
        {
            routine.Value.Invoke(turnEvent.TurnCount);
        }
    }
    /// <summary>
    /// 매턴 실행되는 루틴을 등록합니다. 루틴의 id값을 반환해줍니다.
    /// </summary>
    /// <param name="action"></param>
    /// <returns></returns>
    public int StartTurnRoutine(Action<int> action)
    {
        int key = CreateTurnRoutineKey();
        _turnRoutine.Add(key, action);
        return key;
    }

    public void StopTurnRoutine(int id)
    {
        if(_turnRoutine.ContainsKey(id))
        {
            _turnRoutine.Remove(id);
        }
        else
        {
            Debug.LogError($"Not Found TurnRoutine Key : {id}");
        }
    }
    
    /// <summary>
    /// 턴루틴의 아이디 값을 생성합니다.
    /// </summary>
    /// <returns></returns>
    private int CreateTurnRoutineKey()
    {
        int key = Guid.NewGuid().GetHashCode();
        while (!_turnRoutine.ContainsKey(key))
        {
            key = Guid.NewGuid().GetHashCode();
        }
        return key;
    }
    public void StartCoroutine(IEnumerator coroutine)
    {
        base.StartCoroutine(coroutine);
    }
    public void StopCoroutine(IEnumerator coroutine)
    {
        base.StopCoroutine(coroutine);
    }

    public void Release()
    {
        base.StopAllCoroutines();
    }
}

public struct TurnEvent
{
    public int TurnCount;
}