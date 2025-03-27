using System;
using System.ComponentModel;
using UnityEngine;


public class Monster : Entity, ILoadable, IHittable
{
    public MonsterInfo MonsterInfo { get; private set; }
    public MonsterAnimationController MonsterAnimController { get; private set; }
    public MonsterAI MonsterAI { get; private set; }
    public MonsterPrefab MonsterPrefab { get; private set; }

    public MonsterStatus MonsterStatus { get; private set; }
    
    public void Awake()
    {
        Load(100);
    }

    public void Load(int id)
    {
        MonsterInfo = InfoManager.Instance.Load<MonsterInfo>(id);
        GameObject prefab = ResourceLoader.Instantiate(Path.Monster(id), this.transform);
        
        MonsterPrefab = prefab.GetComponent<MonsterPrefab>();
        InitOnCreate();
    }

    public void InitOnCreate()
    {
        MonsterAnimController = GetComponent<MonsterAnimationController>();
        MonsterAI = GetComponent<MonsterAI>();
        MonsterStatus = GetComponent<MonsterStatus>();
        
        MonsterAnimController.InitOnCreate();
        MonsterAI.InitOnCreate(this);
        MonsterStatus.InitOnCreate(this);
        MonsterPrefab.InitOnCreate(this);
        
        InitOnActivate();
    }

    public void InitOnActivate()
    { 
        MonsterAI.InitOnActivate();
        MonsterStatus.InitOnActivate();
        MonsterPrefab.InitOnActivate();
    }

    public void OnDisable()
    {
        Release();
    }

    public void Release()
    {
        MonsterAnimController.Release();
        MonsterAI.Release();
        MonsterStatus.Release();
        MonsterPrefab.Release();
    }
    
    public void TakeDamage(AttackHandler damage)
    {
        Debug.Log("아야아");
        MonsterStatus.TakeDamage(damage.CalcDamage(MonsterStatus.Stat));
        //쳐맞는 애니메이션
    }
    public void Heal(int heal, bool isOverHeal = false)
    {
        MonsterStatus.Heal(heal, isOverHeal);
    }

    #region AddEvent

    public void AddDieEvent(Action action)
    {
        MonsterStatus.AddDieEvent(action);
    }
    public void AddChangeHpEvent(Action<int,int> action)
    {
        MonsterStatus.AddHpChangeEvent(action);
    }
    public void AddChangeBarrierEvent(Action<int,int> action)
    {
        MonsterStatus.AddBarrierChangeEvent(action);
    }
    public void AddChangeStatEvent(Action<Stat> action)
    {
        MonsterStatus.AddChangeStatEvent(action);
    }

    #endregion
    #region RemoveEvent
    public void RemoveDieEvent(Action action)
    {
        MonsterStatus.RemoveDieEvent(action);
    }
    public void RemoveChangeHpEvent(Action<int,int> action)
    {
        MonsterStatus.RemoveChangeHpEvent(action);
    }
    public void RemoveChangeBarrierEvent(Action<int,int> action)
    {
        MonsterStatus.RemoveChangeBarrierEvent(action);
    }
    public void RemoveChangeStatEvent(Action<Stat> action)
    {
        MonsterStatus.RemoveChangeStatEvent(action);
    }
    

    #endregion



}