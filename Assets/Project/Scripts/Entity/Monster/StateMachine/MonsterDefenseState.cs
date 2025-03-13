public class MonsterDefenseState : MonsterState
{
    public MonsterDefenseState(MonsterAI monsterAI) : base(monsterAI)
    {
    }
    public override void Enter()
    {
        base.Enter();
        // state end 에 idle state로 넘어가게
        _animController.Defense();
    }

    public override void Update()
    {
        base.Update();
    }
    public override void Exit()
    {
        base.Exit();
        _animController.StopDefense();
    }
}