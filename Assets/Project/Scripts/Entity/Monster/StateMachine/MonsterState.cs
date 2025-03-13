using UnityEngine;

public abstract class MonsterState : IState
{
    protected MonsterAI _monsterAI;
    protected MonsterAnimationController _animController => _monsterAI.Monster.MonsterAnimController;
    protected MonsterInfo _monsterInfo => _monsterAI.Monster.MonsterInfo;
    
    public MonsterState(MonsterAI monsterAI)
    {
        _monsterAI = monsterAI;
    }
    
    public virtual void Enter()
    {
    }

    public virtual void Update()
    {
    }

    public virtual void Exit()
    {
    }
}