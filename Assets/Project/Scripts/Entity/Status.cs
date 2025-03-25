using System;
using UnityEngine;

public abstract class Status : MonoBehaviour
{
    public Entity Entity { get; protected set; }
    public StatHandler StatHandler { get; protected set; }
    public ConditionHandler ConditionHandler { get; protected set; }

    public virtual void InitOnCreate(Entity entity)
    {
        Entity = entity;
    }
    public virtual void InitOnActivate()
    {
        StatHandler = new StatHandler(BaseStat());
        ConditionHandler = new ConditionHandler(StatHandler.Stat);

        StatHandler.ChangeEvent += ConditionHandler.SetMaxCondition;
    }

    protected abstract Stat BaseStat();
    
    public void TakeDamage(int damage)
    {
        ConditionHandler.TakeDamage(damage);
    }
    public void Heal(int heal, bool isOverHeal = false)
    {
        ConditionHandler.Heal(heal, isOverHeal);
    }
    
    public void ModifyStat(Stat modifier, bool isAdd = true)
    {
        if (isAdd)
        {
            StatHandler.AddModifier(modifier);
        }
        else
        {
            StatHandler.AddMultiplierModifier(modifier);
        }
    }
    public void RemoveStatModifier(Stat modifier)
    {
        StatHandler.RemoveModifier(modifier);
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

    public void AddChangeStatEvent(Action<Stat> action)
    {
        StatHandler.ChangeEvent += action;
    }

}