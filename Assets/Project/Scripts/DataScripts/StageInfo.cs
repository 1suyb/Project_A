using System.Collections.Generic;
using UnityEngine;

public class StageInfo : LoadedInfoBase
{
     /// <summary>
     /// 스테이지 이름 아이디
     /// </summary>
    public int NameID;
     /// <summary>
     /// 몬스터 id들
     /// </summary>
    public List<int> MonsterIDs;
     /// <summary>
     /// 이벤트 idemf
     /// </summary>
    public List<int> EventIDs;
     /// <summary>
     /// Boss아이디
     /// </summary>
    public int BossID;
     /// <summary>
     /// 몬스터 마리수
     /// </summary>
    public int MonsterCount;
     /// <summary>
     /// 이벤트 개수
     /// </summary>
    public int EventCount;
}

