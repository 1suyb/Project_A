using System.Collections.Generic;
using UnityEngine;

public class WeaponInfo : LoadedInfoBase
{
     /// <summary>
     /// 코드
     /// </summary>
    public string Code;
     /// <summary>
     /// 레어도
     /// </summary>
    public RarityType Rarity;
     /// <summary>
     /// 공격 데미지
     /// </summary>
    public int AttackDamage;
     /// <summary>
     /// 배리어 추가 데미지
     /// </summary>
    public int BarrierBonusDamage;
}

