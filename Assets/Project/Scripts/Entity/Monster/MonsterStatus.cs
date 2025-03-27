using System;
using UnityEngine;

public class MonsterStatus : Status
{
    public Monster Monster { get; private set; }

    public override void InitOnCreate(Entity entity)
    {
        base.InitOnCreate(entity);
        Monster = entity as Monster;
        if(Monster == null)
        {
            Debug.LogError("Entity is not Monster");
            return;
        }
    }
    public override void InitOnActivate()
    {
        base.InitOnActivate();
        
        
        Debug.Log($"StatHandler\n HP : {StatHandler.Stat.Hp} \n Barrier : {StatHandler.Stat.Barrier} \n" +
                  $"Attack : {StatHandler.Stat.Attack} \n BarrierBonusAttack : {StatHandler.Stat.BarrierBonusAttack} \n" +
                  $"CriticalChance : {StatHandler.Stat.CriticalChance}" +
                  $"ConditionHandler\n HP : {ConditionHandler.Hp.ConditionValue}" +
                  $"Barrier : {ConditionHandler.Barrier.ConditionValue}");
    }
    public override void Release()
    {
        base.Release();
    }
    
    protected override Stat BaseStat()
    {
        MonsterInfo info = Monster.MonsterInfo;
        return new StatBuilder()
            .Hp(info.HP)
            .Barrier(info.Barrier)
            .Attack(info.Attack)
            .Build();
    }
}