using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterPrefab : MonoBehaviour
{
    private Monster _monster;
    private MonsterAI _monsterAI => _monster.MonsterAI;
    private MonsterInfo _monsterInfo => _monster.MonsterInfo;
    private MonsterAttack[] _monsterAttacks;
    public void InitOnCreate(Monster monster)
    {
        _monster = monster;
    }

    public void InitOnActivate()
    {
        _monsterAttacks = new MonsterAttack[_monsterInfo.AttackCount];
        List<int> monsterAttackIDs = _monsterInfo.AttackIDs;
        
        for (int i = 0; i < _monsterInfo.AttackCount; i++)
        {
            _monsterAttacks[i] = new MonsterAttack(monsterAttackIDs[i]);
        }
    }
    
    public void Attack()
    {
        _monsterAttacks[_monsterAI.AttackType].Execute();
    }
}

public class MonsterAttack : ICommand
{
    private MonsterAttackInfo _monsterAttackInfo;
    
    public MonsterAttack(int id)
    {
        _monsterAttackInfo = InfoManager.Instance.Load<MonsterAttackInfo>(id);
    }
    public void Execute()
    {
        Debug.Log(_monsterAttackInfo.Code);
        Debug.Log($" 몬스터 공격!");
    }
}