using UnityEngine;

public class MonsterAI : MonoBehaviour
{
    protected IState _currentState;
    
    public Monster Monster { get; private set; }
    public MonsterIdleState IdleState { get; private set; }
    public MonsterAttackState AttackState { get; private set; }
    public MonsterDefenseState DefenseState { get; private set; }
    public MonsterHitState HitState { get; private set; }
    public MonsterDieState DieState { get; private set; }
    public MonsterVictoryState VictoryState { get; private set; }

    public int AttackType => AttackState.AttackType;

    public void InitOnCreate(Monster monster)
    {
        Monster = monster;
        IdleState = new MonsterIdleState(this);
        AttackState = new MonsterAttackState(this);
        DefenseState = new MonsterDefenseState(this);
        HitState = new MonsterHitState(this);
        DieState = new MonsterDieState(this);
        VictoryState = new MonsterVictoryState(this);
    }

    public void InitOnActivate()
    {
        ChangeState(IdleState);
    }
    
    public void ChangeState(IState newState)
    {
        if(_currentState == newState) return;
        if(_currentState != null)
            _currentState.Exit();
        
        _currentState = newState;
        _currentState.Enter();
    }
    
    public void Update()
    {
        _currentState?.Update();
    }
}