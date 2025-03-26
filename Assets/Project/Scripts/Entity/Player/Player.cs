using System;
using UnityEngine;

public class Player : Entity, IHittable
{
    [field: SerializeField] public Transform RightHand { get; private set; }
    [field: SerializeField] public Transform LeftHand { get; private set; }
    
    public PlayerAnimationController PlayerAnimController { get; private set; }
    public PlayerController PlayerController { get; private set; }
    public PlayerStatus PlayerStatus { get; private set; }
    public PlayerEquipment PlayerEquipment { get; private set; }

    public event Action<Equipment> OnEquipped;
    public event Action<Equipment> OnUnequipped;

    private void Awake()
    {
        //InitOnCreate();
    }

    public void InitOnCreate()
    {
        PlayerAnimController = GetComponent<PlayerAnimationController>();
        PlayerController = GetComponent<PlayerController>();
        PlayerStatus = GetComponent<PlayerStatus>();
        PlayerEquipment = GetComponent<PlayerEquipment>();
        
        PlayerAnimController.InitOnCreate(this);
        PlayerController.InitOnCreate(this);
        PlayerStatus.InitOnCreate(this);
        PlayerEquipment.InitOnCreate(this);
    }

    public void InitOnActivate()
    {
        PlayerAnimController.InitOnActivate();
        PlayerStatus.InitOnActivate();
        PlayerEquipment.InitOnActivate();
    }
    
    public void TakeDamage(AttackHandler attackHandler)
    {
        PlayerStatus.TakeDamage(attackHandler.CalcDamage(PlayerStatus.Stat));
    }
    
    public void RaiseEquippedEvent(Equipment equipment)
    {
        OnEquipped?.Invoke(equipment);
    }
    public void RaiseUnEquippedEvent(Equipment equipment)
    {
        OnUnequipped?.Invoke(equipment);
    }
}