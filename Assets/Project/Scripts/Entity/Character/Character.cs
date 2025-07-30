using System;
using UnityEngine;

public class Character : Entity, IHittable
{
    [field: SerializeField] public Transform RightHand { get; private set; }
    [field: SerializeField] public Transform LeftHand { get; private set; }
    
    public CharacterAnimationController CharacterAnimController { get; private set; }
    public CharacterController CharacterController { get; private set; }

    public CharacterEquipment CharacterEquipment { get; private set; }

    public CharacterStatHandler CharacterStatHandler { get; private set; }
    public CharacterConditionHandler CharacterConditionHandler { get; private set; }
    
    public CharacterState CharacterState=> CharacterController.characterState;
    
    public event Action OnHit;
    public event Action OnDeath;
    
    
    public event Action<Equipment> OnEquipped;
    public event Action<Equipment> OnUnequipped;

    public void InitOnCreate()
    {
        CharacterAnimController = GetComponent<CharacterAnimationController>();
        CharacterController = GetComponent<CharacterController>();
        CharacterEquipment = GetComponent<CharacterEquipment>();
        
        CharacterAnimController.InitOnCreate(this);
        CharacterController.InitOnCreate(this);
        CharacterEquipment.InitOnCreate(this);
    }

    public void InitOnActivate()
    {
        CharacterAnimController.InitOnActivate();
        CharacterEquipment.InitOnActivate();
        
        CharacterStatHandler = new CharacterStatHandler(this);
        CharacterConditionHandler = new CharacterConditionHandler(this,CharacterStatHandler);
        
        // TODO : UI Test Code. 나중에 다른데로 옮기기
        UIManager.HUD.PlayerConditionHUD.RegisterEvent();
        EventSubscribe();
    }
    private void EventSubscribe()
    {
        EventRouter.Subscribe<HealEvent>(Heal);
    }

    private void OnDisable()
    {
        Release();
    }

    public void Release()
    {
        EventUnsubscribe();
    }
    private void EventUnsubscribe()
    {
        EventRouter.Unsubscribe<HealEvent>(Heal);
    }
    
    public void TakeDamage(AttackHandler attackHandler)
    {
        if(CharacterState == CharacterState.Defense || 
           CharacterState == CharacterState.Hit ||
           CharacterState == CharacterState.Dead)
            return;
    }
    public void Heal(HealEvent healEvent)
    {
        if (CharacterState == CharacterState.Dead)
            return;
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