using System;
using UnityEngine;

public class ConditionHandler
{
    public Condition Hp { get; private set; }
    public Condition Barrier { get; private set; }

    public Action DieEvent;
    
    public ConditionHandler(Stat stat)
    {
        Hp = new Condition(stat.Hp, true);
        Barrier = new Condition(stat.Barrier, false);
    }
    public void TakeDamage(int damage)
    {
        if (Barrier > 0)
        {
            damage = -Barrier.Sub(damage);
        }
        if(damage <= 0)
        {
            return;
        }
        Hp.Sub(damage);
        if(Hp.IsDie)
        {
            DieEvent?.Invoke();
        }
    }

    public void Heal(int heal, bool isOverHeal = false)
    {
        Hp.Add(heal);
        Debug.Log("회복!");
    }

    public void SetMaxCondition(Stat stat)
    {
        Hp.MaxCondition = stat.Hp;
        Barrier.MaxCondition = stat.Barrier;
    }
}