using System.Collections.Generic;
using UnityEngine;

public class EventInfo : LoadedInfoBase
{
     /// <summary>
     /// 스테이지 이름 아이디
     /// </summary>
    public int NameID;
     /// <summary>
     /// 스테이지 설명 id
     /// </summary>
    public int DescriptionID;
     /// <summary>
     /// 이벤트 타입
     /// </summary>
    public RoundType EventType;
     /// <summary>
     /// 버프 id들
     /// </summary>
    public List<int> BuffIDs;
}

