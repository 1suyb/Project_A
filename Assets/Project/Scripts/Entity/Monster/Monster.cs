using System;
using UnityEngine;


public class Monster : Entity, ILoadable, IHittable
{
    public MonsterInfo MonsterInfo { get; private set; }
    public MonsterAnimationController MonsterAnimController { get; private set; }
    public MonsterAI MonsterAI { get; private set; }
    public MonsterPrefab MonsterPrefab { get; private set; }
    public MonsterStatHandler MonsterStatHandler { get; private set; }
    public MonsterConditionHandler MonsterConditionHandler { get; private set; }

    public event Action OnHit;
    public event Action OnDeath;
    public event Action<ConditionChangeArgs> OnChangeBarrier;
    public event Action<ConditionChangeArgs> OnChangeHp;
    public event Action OnDisabled;

    public bool IsDamageable => MonsterAI.IsDamageable;
    public bool IsHittable => MonsterAI.IsHittable;

    public void Load(int id)
    {
        MonsterInfo = InfoManager.Instance.Load<MonsterInfo>(id);
        GameObject prefab = ResourceLoader.Instantiate(Path.Monster(id), this.transform);
        
        MonsterPrefab = prefab.GetComponent<MonsterPrefab>();
        InitOnCreate();
    }

    public void InitOnCreate()
    {
        MonsterAI = GetComponent<MonsterAI>();
        MonsterAnimController = GetComponent<MonsterAnimationController>();

        MonsterAnimController.InitOnCreate();
        MonsterAI.InitOnCreate(this);
        MonsterPrefab.InitOnCreate(this);
        
    }

    public void InitOnActivate()
    { 
        gameObject.SetActive(true);
        
        MonsterAI.InitOnActivate();
        MonsterPrefab.InitOnActivate();
        MonsterAnimController.InitOnActivate();
        
        MonsterStatHandler = new MonsterStatHandler(this);
        MonsterConditionHandler = new MonsterConditionHandler(this, MonsterStatHandler);

    }

    public void OnDisable()
    {
        Release();
    }

    public void Release()
    {
        if (MonsterAnimController != null) MonsterAnimController.Release();
        if (MonsterAI != null) MonsterAI.Release();
        //if (MonsterStatHandler != null) MonsterStatHandler.Release();
        if (MonsterPrefab != null) MonsterPrefab.Release();
        OnDisabled?.Invoke();
        OnDisabled = null;
    }
    
    public void TakeDamage(AttackHandler attackHandler)
    {
        if (IsHittable)
        {
            OnHit?.Invoke();
        }
        if (IsDamageable)
        {
            //MonsterStatHandler.TakeDamage(attackHandler);
        }
        
    }
    public void Heal(int heal, bool isOverHeal = false)
    {
        //MonsterStatHandler.Heal(heal, isOverHeal);
    }
    
    
}