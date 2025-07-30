using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerConditionHUD : HUD
{
    [SerializeField] private ConditionHUD _playerCondition;
    
    /// <summary>
    /// 이벤트 라우터에 이벤트를 등록합니다.
    /// </summary>
    public void RegisterEvent()
    {
    }
    /// <summary>
    /// 이벤트 라우터에서 이벤트를 제거합니다.
    /// </summary>
    public void UnregisterEvent()
    {
    }

    private void ChangeCondition( )
    {
        /*if (evt.ConditionChangeArgs.IsHp)
        {
            _playerCondition.SetHPFill(evt.ConditionChangeArgs);
        }
        else
        {
            _playerCondition.SetBarrierFill(evt.ConditionChangeArgs);
        }*/
    }
}
