public class MonsterHitState : MonsterState
{
    public MonsterHitState(MonsterAI monsterAI) : base(monsterAI)
    {
    }
    public override void Enter()
    {
        base.Enter();
        // state end 에 idle state로 넘어가게
        _animController.Hit();
        _animController.AddAnimEndEvent<HitStateBehaviour>(ChangeState);
    }

    public override void Update()
    {
        base.Update();
    }
    public override void Exit()
    {
        base.Exit();
        _animController.RemoveAnimEndEvent<HitStateBehaviour>(ChangeState);
    }
    private void ChangeState()
    {
        _monsterAI.ChangeState(_monsterAI.IdleState);
    }
}