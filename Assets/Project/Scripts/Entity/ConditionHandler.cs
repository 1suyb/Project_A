using System;
using UnityEngine;

public class ConditionHandler
{
    protected Entity _entity;
    public Condition HpCondition { get; private set; }
    public Condition BarrierCondition { get; private set; }
    
    public int Hp=> HpCondition.ConditionValue;
    public int Barrier => BarrierCondition.ConditionValue;
    
    public ConditionHandler(Entity entity, StatHandler statHandler)
    {
        HpCondition = new Condition(statHandler.Stat.Hp, new NoAutoRecoveryPolicy());
        BarrierCondition = new Condition(statHandler.Stat.Barrier, new NoAutoRecoveryPolicy());
        statHandler.OnChange += SetMaxCondition;
    }

    public void Release()
    {
        HpCondition.Release();
        BarrierCondition.Release();
    }
    
    
    public void SetMaxCondition(Stat stat)
    {
        HpCondition.MaxCondition = stat.Hp;
        BarrierCondition.MaxCondition = stat.Barrier;
    }
}

public class MonsterConditionHandler : ConditionHandler
{
    private Monster _monster;
    public Condition FatigueGauge { get; private set; }
    public MonsterConditionHandler(Entity entity, StatHandler statHandler) : base(entity, statHandler)
    {
        _monster = entity as Monster;
        FatigueGauge = new Condition(_monster.MonsterInfo.FatigueGauge, new NoAutoRecoveryPolicy());
    }
}

public class CharacterConditionHandler : ConditionHandler
{
    private Character _character;
    public CharacterConditionHandler(Entity entity, StatHandler statHandler) : base(entity, statHandler)
    {
        _character = entity as Character;
        
    }
}