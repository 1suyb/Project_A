using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage : MonoBehaviour
{
    private readonly int _roundSpacing = 10;
    private readonly Vector3 _roundStartPosition = new Vector3(0, 0, 5);
    
    public List<RoundData> RoundDatas = new List<RoundData>()
    {
        new RoundData(RoundType.Monster, 101, 101),
        new RoundData(RoundType.Recovery, 50, 10),
        new RoundData(RoundType.Monster, 100, 100),
        /*new RoundData(RoundType.Damage, 50, 10),
        new RoundData(RoundType.Boss, 200, 100),*/
    };

    public List<Round> Rounds;
    
    public int CurrentRoundIndex { get; private set; }

    //Todo : 다른데서 초기화 하게 
    private void Awake()
    {
        InitOnCreate();
    }
    
    public void InitOnCreate()
    {
        Rounds = new List<Round>()
        {
            new MonsterRound(new RoundData(RoundType.Monster, 100, 101),RoundClear),
            new MonsterRound(new RoundData(RoundType.Monster, 100, 100),RoundClear),
            new MonsterRound(new RoundData(RoundType.Monster, 100, 100),RoundClear),
            new EventRound(new RoundData(RoundType.Recovery, 50, 10),RoundClear)
        };
    }

    public void Start()
    {
        InitOnActivate();
    }

    public void InitOnActivate()
    {
        // 라운드 구성
        CurrentRoundIndex = 0;
        SpawnRound(CurrentRoundIndex);
    }

    public void SpawnRound(int roundIndex)
    {
        Rounds[roundIndex].Spawn(this.transform);
    }

    private void GameOver()
    {
        
    }

    private void RoundClear()
    {
        Debug.Log("Round Clear");
        if(RoundDatas.Count > CurrentRoundIndex + 1)
        {
            CurrentRoundIndex++;
            SpawnRound(CurrentRoundIndex);
        }
        else
        {
            StageClear();
        }
    }

    private void StageClear()
    {
        UIManager.Popup.GameOver(() => { Application.Quit();});
    }

}