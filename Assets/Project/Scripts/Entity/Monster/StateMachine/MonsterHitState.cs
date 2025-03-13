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
    }

    public override void Update()
    {
        base.Update();
    }
    public override void Exit()
    {
        base.Exit();
    }
}