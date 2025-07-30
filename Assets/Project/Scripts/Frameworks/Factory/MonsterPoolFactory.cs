using System.Collections.Generic;
using UnityEngine;

public class MonsterPoolFactory : PoolFactory
{
    /// <summary>
    /// 몬스터를 새로 생성
    /// </summary>
    /// <param name="id"></param>
    /// <param name="parent"></param>
    /// <returns></returns>
    private Monster CreateMonster(int id, Transform parent = null)
    {
        Monster monster = CreateObj(Path.Base.Monster, id, parent).GetComponent<Monster>();
        
        #if Unity_EDITOR
        if(!InfoManager.Instance.Contains<MonsterInfo>(id))
        {
           Debug.Assert(InfoManager.Instance.Contains<MonsterInfo>(id), $"Invalid Monster ID: {id}");
        }
        #endif
        monster.Load(id);
        return monster;
    }
    /// <summary>
    /// 풀에서 몬스터를 가져옴 풀이 없거나 풀에 몬스ㅓ가 없으면 새로 생성
    /// </summary>
    /// <param name="id"></param>
    /// <param name="parent"></param>
    /// <returns></returns>
    private Monster FetchMonster(int id, Transform parent = null)
    {
        if (_pool.ContainsKey(id))
        {
            Queue<Poolable> monsters = _pool[id];
            if(monsters.Count > 0)
            {
                Poolable obj = monsters.Dequeue();
                Monster monster = obj.GetComponent<Monster>();
                return monster;
            }
        }
        else
        {
            _pool.Add(id, new Queue<Poolable>());
        }
        Monster newMonster = CreateMonster(id,parent);
        return newMonster;
    }
    
    public Monster SpawnMonster(int id, Transform parent)
    {
        Monster monster = FetchMonster(id, parent);
        monster.InitOnActivate();
        // TODO : HUD 등록은 다른 곳에 빼기
        UIManager.HUD.MonsterConditionHUD.RegisterMonster(monster);
        return monster;
    }
}