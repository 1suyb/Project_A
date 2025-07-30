using UnityEngine;

public class MonsterAI : MonoBehaviour
{
    protected IState _currentState;
    
    public Monster Monster { get; private set; }
    public MonsterIdleState IdleState { get; private set; }
    public MonsterAttackState AttackState { get; private set; }
    public MonsterDefenseState DefenseState { get; private set; }
    public MonsterGroggyState GroggyState { get; private set; }
    public MonsterHitState HitState { get; private set; }
    public MonsterDieState DieState { get; private set; }
    public MonsterVictoryState VictoryState { get; private set; }

    public int AttackType => AttackState.AttackType;
    public bool IsDamageable => _currentState is MonsterHitState;
    public bool IsHittable => _currentState is MonsterGroggyState | _currentState is MonsterDefenseState;

    public void InitOnCreate(Monster monster)
    {
        Monster = monster;
        IdleState = new MonsterIdleState(this);
        AttackState = new MonsterAttackState(this);
        DefenseState = new MonsterDefenseState(this);
        GroggyState = new MonsterGroggyState(this);
        HitState = new MonsterHitState(this);
        DieState = new MonsterDieState(this);
        VictoryState = new MonsterVictoryState(this);
    }

    public void InitOnActivate()
    {
        ChangeState(IdleState);
        
        Monster.OnDeath += Die;
        Monster.OnHit += Hit;
    }

    private void Die()
    {
        ChangeState(DieState);
    }

    private void Hit()
    {
        ChangeState(HitState);
    }

    public void Release()
    {
        _currentState = null;
        //Monster.RemoveDieEvent(Die);
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