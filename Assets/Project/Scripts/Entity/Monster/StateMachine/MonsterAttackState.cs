using UnityEngine;

public class MonsterAttackState : MonsterState
{
    public int AttackType { get; private set; }
    public MonsterAttackState(MonsterAI monsterAI) : base(monsterAI)
    {
        
    }
    public override void Enter()
    {
        _animController.AddAnimEndEvent<AttackStateBehaviour>(AttackEnd);
        base.Enter();
        AttackType = Random.Range(0, _monsterInfo.AttackCount);
        _animController.Attack(AttackType);
    }

    public override void Update()
    {
        base.Update();
    }
    
    public override void Exit()
    {
        base.Exit();
        _animController.RemoveAnimEndEvent<AttackStateBehaviour>(AttackEnd);
        _animController.StopAttack();
    }
    private void AttackEnd()
    {
        _monsterAI.ChangeState(_monsterAI.IdleState);
    }
}