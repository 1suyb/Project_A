using UnityEngine;

public class MonsterDefenseState : MonsterState
{
    private float _maxTime;
    private float _time;
    public MonsterDefenseState(MonsterAI monsterAI) : base(monsterAI)
    {
    }
    public override void Enter()
    {
        base.Enter();
        // state end 에 idle state로 넘어가게
        _maxTime = Random.Range(_monsterInfo.MaxDefenseTime[0], _monsterInfo.MaxDefenseTime[1]);
        _time = 0;
        _animController.Defense();
    }

    public override void Update()
    {
        base.Update();
        _time += Time.deltaTime;
        if (_time > _maxTime)
        {
            _monsterAI.ChangeState(_monsterAI.IdleState);
        }
    }
    public override void Exit()
    {
        base.Exit();
        _animController.StopDefense();
    }
}