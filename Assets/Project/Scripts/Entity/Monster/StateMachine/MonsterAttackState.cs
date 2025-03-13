using UnityEngine;

public class MonsterAttackState : MonsterState
{
    public int AttackType { get; private set; }
    public MonsterAttackState(MonsterAI monsterAI) : base(monsterAI)
    {
        _animController.AddAnimEndEvent<AttackStateBehaviour>(AttackEnd);
    }
    public override void Enter()
    {
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
        _animController.StopAttack();
    }
    private void AttackEnd()
    {
        _monsterAI.ChangeState(_monsterAI.IdleState);
    }
}