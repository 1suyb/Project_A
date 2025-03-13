using System.Collections.Generic;
using UnityEngine;

public class MonsterInfo : LoadedInfoBase
{
     /// <summary>
     /// 코드
     /// </summary>
    public string Code;
     /// <summary>
     /// 체력
     /// </summary>
    public int HP;
     /// <summary>
     /// 방어막
     /// </summary>
    public int Barrier;
     /// <summary>
     /// 최대 대기 시간
     /// </summary>
    public float MaxIdleTime;
     /// <summary>
     /// 방어 자세 존재
     /// </summary>
    public bool HasDefense;
     /// <summary>
     /// 공격 개수
     /// </summary>
    public int AttackCount;
     /// <summary>
     /// 공격 아이디
     /// </summary>
    public List<int> AttackIDs;
     /// <summary>
     /// 대기중 공격 확률 - 백분율
     /// </summary>
    public int IdleActionChance;
     /// <summary>
     /// 대기중 방어 확률
     /// </summary>
    public int DefenseChance;
}

