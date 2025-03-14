using System;
using UnityEngine;

public class ConditionHandler
{
    public Condition Hp { get; private set; }
    public Condition Barrier { get; private set; }

    public Action DieEvent;
    
    public void TakeDamage(int damage)
    {
        Hp.Sub(damage);
        Debug.Log("쳐마즘!");
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
}