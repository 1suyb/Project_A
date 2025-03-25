using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerEventReceiver", menuName = "ScriptableObjects/Events/PlayerEventReceiver")]

public class PlayerEventReceiver : ScriptableObject
{
    public event Action OnDeath;
    public event Action OnVictory;
    
    public event Action OnHit;
    public event Action OnHeal;

    public event Action OnChangeHp;
    public event Action OnChangeBarrier;

    public event Action<Equipment> OnEquip;
    public event Action<Equipment> OnUnEquip;
    
    public void Die() => OnDeath?.Invoke();
    public void Victory() => OnVictory?.Invoke();
    
    public void Hit() => OnHit?.Invoke();

    public void Heal() => OnHeal?.Invoke();
    
    public void ChangeHp() => OnChangeHp?.Invoke();
    public void ChangeBarrier() => OnChangeBarrier?.Invoke();
    public void Equip(Equipment equipment) => OnEquip?.Invoke(equipment);

    public void UnEquip(Equipment equipment) => OnUnEquip?.Invoke(equipment);
}