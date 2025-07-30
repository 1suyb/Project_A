using System;
using UnityEngine;

public class EventRound : Round
{
    public EventRound(RoundData roundData,Action action) : base(roundData,action)
    {
        
    }
    public override void Spawn(Transform transform = null)
    {
        UIManager.Popup.EventConfirm("회복의 샘",$"{value}만큼 회복할 수 있습니다. 회복하시겠습니까?",Execute,OnRoundEnd);
    }

    private void Execute()
    {
        EventRouter.Publish(new HealEvent(value, false));
        OnRoundEnd?.Invoke();
    }
    
}
