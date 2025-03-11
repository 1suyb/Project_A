using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityCondition
{
    public int MaxHp { get; private set; }
    public int MaxBarrier { get; private set; }

    private int _hp;
    private int _barrier;
    public int Hp
    {
        get => _hp;
        private set
        {
            _hp =  value >= 0 ? value : 0;
            OnChangeHp?.Invoke(_hp);
            if (_hp <= 0)
            {
                OnDeath?.Invoke();
            }
        }
    }

    public int Barrier
    {
        get => _barrier;
        private set
        {
            _barrier = value>=0 ? value : 0;
            OnChangeBarrier?.Invoke(_barrier);
            if (_barrier <= 0)
            {
                OnShieldBroken?.Invoke();
            }
        }
    }
    public bool IsDead => Hp <= 0;
    public bool IsShieldBroken => Barrier <= 0;
    
    public event Action OnDeath;
    public event Action OnShieldBroken;
    public event Action<int> OnChangeHp;
    public event Action<int> OnChangeBarrier;

    public void InitOnCreate(int maxHp, int maxBarrier)
    {
        MaxHp = maxHp;
        MaxBarrier = maxBarrier;
        InitOnActivate();
    }

    public void InitOnActivate()
    {
        Hp = MaxHp;
        Barrier = MaxBarrier;
    }
    
    public void TakeDamage(int damage)
    {
        if (Barrier > 0)
        {
            if(Barrier<damage)
            {
                damage -= Barrier;
                Barrier = 0;
                Hp -= damage;
            }
            else
            {
                Barrier -= damage;
            }
        }
        else
        {
            Hp -= damage;
        }
        Debug.Log("Hp: " + Hp + " Shield: " + Barrier);
    }

    public void Heal(int heal, bool isOverHealAllowed = false)
    {
        if (Hp + heal > MaxHp && !isOverHealAllowed)
        {
            Hp = MaxHp;
        }
        else
        {
            Hp += heal;
        }
    }

    public void RecoverBarrier(int barrier, bool isOverHealAllowed = false)
    {
        if(Barrier + barrier > MaxBarrier && !isOverHealAllowed)
        {
            Barrier = MaxBarrier;
        }
        else
        {
            Barrier += barrier;
        }
    }
}
