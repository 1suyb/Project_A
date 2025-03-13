public class MonsterVictoryState : MonsterState
{
    public MonsterVictoryState(MonsterAI monsterAI) : base(monsterAI)
    {
    }
    public override void Enter()
    {
        base.Enter();
        _animController.Victory();
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