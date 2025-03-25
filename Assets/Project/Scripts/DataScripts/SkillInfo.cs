using System.Collections.Generic;
using UnityEngine;

public class SkillInfo : LoadedInfoBase
{
     /// <summary>
     /// 코드
     /// </summary>
    public string Code;
     /// <summary>
     /// 데미지 비율 백분율
     /// </summary>
    public int DamageRate;
     /// <summary>
     /// 타격 횟수
     /// </summary>
    public int HitCount;
     /// <summary>
     /// 투사체 id
     /// </summary>
    public int ProjectileID;
     /// <summary>
     /// 버프 id
     /// </summary>
    public List<int> BuffIDs;
     /// <summary>
     /// 대상 타입
     /// </summary>
    public TargetType TargetType;
}

