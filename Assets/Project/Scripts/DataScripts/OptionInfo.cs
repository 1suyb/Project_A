using System.Collections.Generic;
using UnityEngine;

public class OptionInfo : LoadedInfoBase
{
     /// <summary>
     /// 코드
     /// </summary>
    public string Code;
     /// <summary>
     /// 옵션
     /// </summary>
    public OptionType OptionType;
     /// <summary>
     /// 비율증가인가?
     /// </summary>
    public bool IsPercent;
     /// <summary>
     /// 값 percentage인경우 만분율
     /// </summary>
    public int Value;
     /// <summary>
     /// 지속시간 -1인경우 특별한 제거 요청이 있을 때까지 영구지속
     /// </summary>
    public float Time;
}

