using System;
using UnityEngine;

public abstract class Status : MonoBehaviour
{
    /*public Entity Entity { get; protected set; }
    public StatHandler StatHandler { get; protected set; }
    
    public Condition HpCondition { get; protected set; }
    public Condition BarrierCondition { get; protected set; }
    
    public int Hp => HpCondition.ConditionValue;
    public int Barrier => BarrierCondition.ConditionValue;
    
    public Stat Stat => StatHandler.Stat;

    public virtual void InitOnCreate(Entity entity)
    {
        Entity = entity;
    }
    public virtual void InitOnActivate()
    {
        //StatHandler ??= new StatHandler(BaseStat());
        HpCondition ??= new Condition(StatHandler.Stat.Hp, true);
        BarrierCondition ??= new Condition(StatHandler.Stat.Barrier, false);
    }

    public virtual void Release()
    {
        
    }

    protected abstract Stat BaseStat();
    
    public void ModifyStat(Stat modifier, bool isAdd = true)
    {
        if (isAdd)
        {
            //StatHandler.AddPlusModifier(modifier);
        }
        else
        {
            //StatHandler.AddMultiplierModifier(modifier);
        }
        UpdateCondition();
    }
    
    public void RemoveStatModifier(Stat modifier)
    {
        //StatHandler.RemoveModifier(modifier);
    }

    public virtual void UpdateCondition()
    {
        HpCondition.MaxCondition = StatHandler.Stat.Hp;
        BarrierCondition.MaxCondition = StatHandler.Stat.Barrier;
    }
    
    public void TakeDamage(AttackHandler attackHandler)
    {
        //attackHandler.ApplyDamage(BarrierCondition, HpCondition);
    }
    public void Heal(int heal, bool isOverHeal = false)
    {
        
    }
    
    
    public void AddDieEvent(Action action)
    {
        HpCondition.OnExhausted += action;
    }
    public void AddHpChangeEvent(Action<ConditionChangeArgs> action)
    {
        HpCondition.OnChange += action;
    }
    public void AddBarrierChangeEvent(Action<ConditionChangeArgs> action)
    {
        BarrierCondition.OnChange += action;
    }
    public void AddChangeStatEvent(Action<Stat> action)
    {
        StatHandler.OnChange += action;
    }
    

    public void RemoveDieEvent(Action action)
    {
        HpCondition.OnExhausted -= action;
    }
    public void RemoveHpChangeEvent(Action<ConditionChangeArgs> action)
    {
        HpCondition.OnChange -= action;
    }
    public void RemoveBarrierChangeEvent(Action<ConditionChangeArgs> action)
    {
        BarrierCondition.OnChange -= action;
    }
    public void RemoveChangeStatEvent(Action<Stat> action)
    {
        StatHandler.OnChange -= action;
    }*/
}