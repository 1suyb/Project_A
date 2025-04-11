using System;
using UnityEngine;

public class RoundEvent : MonoBehaviour
{
    public RoundData RoundData { get; private set; }
    public event Action OnEventEnd;

    private int value;
    public void InitOnCreate(RoundData roundData)
    {
        RoundData = roundData;
        value = roundData.Value;
    }

    public void InitOnActivate()
    {
        UIManager.Popup.EventConfirm("회복의 샘",$"{value}만큼 회복할 수 있습니다. 회복하시겠습니까?",EventExcute,OnEventEnd);
    }

    private void EventExcute()
    {
        EventRouter.Publish(new HealEvent(value, false));
        this.gameObject.SetActive(false);
        OnEventEnd?.Invoke();
    }
    
}