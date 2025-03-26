using System.Collections.Generic;
using UnityEngine;

public class EquipmentInfo : LoadedInfoBase
{
     /// <summary>
     /// 이름string code
     /// </summary>
    public int NameID;
     /// <summary>
     /// 설명 string code
     /// </summary>
    public int DescriptionID;
     /// <summary>
     /// 레어도
     /// </summary>
    public RarityType Rarity;
     /// <summary>
     /// 종류
     /// </summary>
    public EquipType EquipType;
     /// <summary>
     /// 옵션Id들
     /// </summary>
    public List<int> OptionIDs;
}

