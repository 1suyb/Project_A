public class MonsterDieState : MonsterState
{
    public MonsterDieState(MonsterAI monsterAI) : base(monsterAI)
    {
    }
    public override void Enter()
    {
        base.Enter();
        _animController.Die();
    }

    public override void Update()
    {
        base.Update();
    }
    public override void Exit()
    {
        base.Exit();
        // set activate false하기
    }
}