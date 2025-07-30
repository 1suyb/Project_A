using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterPrefab : MonoBehaviour
{
    private Monster _monster;
    private MonsterAI _monsterAI => _monster.MonsterAI;
    private MonsterInfo _monsterInfo => _monster.MonsterInfo;
    private Stat Stat => _monster.MonsterStatHandler.Stat;
    private Skill[] _skills;
    public void InitOnCreate(Monster monster)
    {
        _monster = monster;
    }

    public void InitOnActivate()
    {
        List<int> monsterAttackIDs = _monsterInfo.AttackIDs;
        if (_skills != null)
        {
            return;
        }
        
        _skills = new Skill[_monsterInfo.AttackCount];
        for (int i = 0; i < _monsterInfo.AttackCount; i++)
        {
            _skills[i] = new Skill(monsterAttackIDs[i], Stat);
        }
    }
    public void Release()
    {
    }
    
    public void Attack()
    {
        _skills[_monsterAI.AttackType].Execute(GameManager.Instance.Character);
    }
    
}