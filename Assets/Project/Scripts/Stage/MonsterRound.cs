using System;
using UnityEngine;

public class MonsterRound : Round
{
    
    public MonsterRound(RoundData roundData, Action action) : base(roundData, action)
    {
        
    }
    public override void Spawn(Transform transform = null)
    {
        
        MonsterPoolFactory monsterPoolFactory = FactoryManager.MonsterPoolFactory;
        Monster monster =  monsterPoolFactory.SpawnMonster(value, transform);
        GameManager.Instance.Monster = monster;
        monster.OnDisabled += OnRoundEnd;
    }
}