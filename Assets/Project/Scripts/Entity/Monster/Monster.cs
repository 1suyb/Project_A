using System;
using UnityEngine;


public class Monster : Entity, ILoadable, IHittable
{
    public MonsterInfo MonsterInfo { get; private set; }
    public MonsterAnimationController MonsterAnimController { get; private set; }
    public MonsterAI MonsterAI { get; private set; }
    public MonsterPrefab MonsterPrefab { get; private set; }

    public MonsterStatus MonsterStatus { get; private set; }

    public event Action OnDisabled;
    
    /*public void Awake()
    {
        Load(100);
    }*/

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
    }

    public void InitOnActivate()
    { 
        // TODO : 몬스터 AI에서 Status의 Die를 참조해야해서 Status와 AI 순서간의 의존성 문제 발생
        MonsterStatus.InitOnActivate();
        MonsterAI.InitOnActivate();
        MonsterPrefab.InitOnActivate();
        
        // TODO : UI Test Code. 나중에 다른데로 옮기기
        UIManager.HUD.MonsterConditionHUD.RegisterMonster(this);
        MonsterAnimController.AddAnimEndEvent<DieStateBehaviour>(()=>{this.gameObject.SetActive(false);});
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
        OnDisabled?.Invoke();
        OnDisabled = null;
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
    public void AddChangeHpEvent(Action<ConditionChangeArgs> action)
    {
        MonsterStatus.AddHpChangeEvent(action);
    }
    public void AddChangeBarrierEvent(Action<ConditionChangeArgs> action)
    {
        MonsterStatus.AddBarrierChangeEvent(action);
    }
    public void AddChangeStatEvent(Action<Stat> action)
    {
        MonsterStatus.AddChangeStatEvent(action);
    }

    public void AddDisableEvent(Action action)
    {
        OnDisabled += action;
    }

    #endregion
    #region RemoveEvent
    public void RemoveDieEvent(Action action)
    {
        MonsterStatus.RemoveDieEvent(action);
    }
    public void RemoveChangeHpEvent(Action<ConditionChangeArgs> action)
    {
        MonsterStatus.RemoveHpChangeEvent(action);
    }
    public void RemoveChangeBarrierEvent(Action<ConditionChangeArgs> action)
    {
        MonsterStatus.RemoveBarrierChangeEvent(action);
    }
    public void RemoveChangeStatEvent(Action<Stat> action)
    {
        MonsterStatus.RemoveChangeStatEvent(action);
    }
    

    #endregion



}