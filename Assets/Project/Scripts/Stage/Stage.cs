using System;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    
    public List<RoundData> Rounds = new List<RoundData>()
    {
        new RoundData(RoundType.Monster, 100, 100),
        new RoundData(RoundType.Recovery, 50, 10)
        /*new RoundData(RoundType.Damage, 50, 10),
        new RoundData(RoundType.Boss, 200, 100),*/
    };

    public int CurrentRoundIndex { get; private set; }

    public void InitOnCreate()
    {

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
        RoundData roundData = Rounds[roundIndex];
        switch (roundData.RoundType)
        {
            case RoundType.Monster:
                SpawnMonster(roundData);
                break;
            case RoundType.Boss:
                Debug.Log("Spawn Boss");
                break;
            case RoundType.Recovery:
                SpawnEvent(roundData);
                break;
            case RoundType.Damage:
                Debug.Log("Spawn Damage Event");
                break;
            case RoundType.RandomEffect:
                Debug.Log("Spawn Buff Event");
                break;
        }
    }

    private void GameOver()
    {
        
    }

    private void RoundClear()
    {
        Debug.Log("Round Clear");
        if(Rounds.Count > CurrentRoundIndex + 1)
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
        Debug.Log("Stage Clear");
    }
    public void SpawnMonster(RoundData roundData)
    {
        GameObject obj = ResourceLoader.Instantiate(Path.Base.Monster, this.transform);
        Monster monster = obj.GetComponent<Monster>();
        monster.Load(roundData.Value);
        monster.InitOnActivate();
        monster.AddDisableEvent(RoundClear);
        GameManager.Instance.Monster = monster;
    }
    public void SpawnEvent(RoundData roundData)
    {
        // TODO : 이벤트 스폰
        GameObject obj = ResourceLoader.Instantiate(Path.Base.Event, this.transform);
        RoundEvent round = obj.GetComponent<RoundEvent>();
        round.OnEventEnd += RoundClear;
        round.InitOnCreate(roundData);
        round.InitOnActivate();
    }
}