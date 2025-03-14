using System;
using UnityEngine;

public class MonsterStatus : MonoBehaviour
{
    public Monster Monster { get; private set; }
    public StatHandler StatHandler { get; private set; }
    public ConditionHandler ConditionHandler { get; private set; }

    public void InitOnCreate(Monster monster)
    {
        Monster = monster;
    }
    
    public void InitOnActivate()
    {
        StatHandler = new StatHandler(BaseStat());
        ConditionHandler = new ConditionHandler(StatHandler.Stat);
        
        Debug.Log($"StatHandler\n HP : {StatHandler.Stat.Hp} \n Barrier : {StatHandler.Stat.Barrier} \n" +
                  $"Attack : {StatHandler.Stat.Attack} \n BarrierBonusAttack : {StatHandler.Stat.BarrierBonusAttack} \n" +
                  $"CriticalChance : {StatHandler.Stat.CriticalChance}");
        Debug.Log($"ConditionHandler\n HP : " + ConditionHandler.Hp.ConditionValue + "\n Barrier : " + ConditionHandler.Barrier.ConditionValue);
    }
    
    private Stat BaseStat()
    {
        MonsterInfo info = Monster.MonsterInfo;
        return new StatBuilder()
            .Hp(info.HP)
            .Barrier(info.Barrier)
            .Build();
    }
    
    public void TakeDamage(int damage)
    {
        ConditionHandler.TakeDamage(damage);
    }
    public void Heal(int heal, bool isOverHeal = false)
    {
        ConditionHandler.Heal(heal, isOverHeal);
    }

    public void AddDieEvent(Action action)
    {
        ConditionHandler.DieEvent += action;
    }
    public void AddHpChangeEvent(Action<int> action)
    {
        ConditionHandler.Hp.ChangeEvent += action;
    }
    public void AddBarrierChangeEvent(Action<int> action)
    {
        ConditionHandler.Barrier.ChangeEvent += action;
    }
}