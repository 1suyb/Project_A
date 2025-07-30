using UnityEngine;

public class MonsterGroggyState : MonsterState
{
    private float time;
    private float MaxGroggyTime = 5f;
    public MonsterGroggyState(MonsterAI monsterAI) : base(monsterAI)
    {
    }

    public override void Enter()
    {
        base.Enter();
        time = 0;
        _animController.Groggy();
    }
    public override void Update()
    {
        time += Time.deltaTime;
        if (time > MaxGroggyTime)
        {
            _monsterAI.ChangeState(_monsterAI.IdleState);
        }
    }
    public override void Exit()
    {
        time = 0;
        _animController.StopGroggy();
    }
}