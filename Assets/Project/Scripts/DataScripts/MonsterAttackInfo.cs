using System.Collections.Generic;
using UnityEngine;

public class MonsterAttackInfo : LoadedInfoBase
{
     /// <summary>
     /// 코드
     /// </summary>
    public string Code;
     /// <summary>
     /// 데미지
     /// </summary>
    public int Damage;
     /// <summary>
     /// 원거리공격인가
     /// </summary>
    public bool IsRange;
     /// <summary>
     /// 원거리공격이면, 투사체 아이디
     /// </summary>
    public int ProjectileID;
}

