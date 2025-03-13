using UnityEngine;

public class MonsterIdleState : MonsterState
{
    private float time;
    public MonsterIdleState(MonsterAI monsterAI) : base(monsterAI)
    {
    }

    public override void Enter()
    {
        base.Enter();
        time = 0;
        _animController.Battle();
    }

    public override void Update()
    {
        time += Time.deltaTime;
        if (time > _monsterInfo.MaxIdleTime)
        {
            Act();
        }
        else
        {
            RandomAct();
        }
    }
    
    public override void Exit()
    {
    }

    private void Act()
    {
        int random = Random.Range(0, 100);
        if (_monsterInfo.HasDefense)
        {
            if (random < _monsterInfo.DefenseChance)
            {
                _monsterAI.ChangeState(_monsterAI.DefenseState);
                return;
            }
        }
        _monsterAI.ChangeState(_monsterAI.AttackState);

    }

    private void RandomAct()
    {
        int random = Random.Range(0, 100);
        if(_monsterInfo.IdleActionChance > random)
        {
           Act();
        }
    }
}