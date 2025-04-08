using UnityEngine;
using UnityEngine.UI;

public class ConditionHUD : HUD
{
    [SerializeField] private Image _hpFill;
    [SerializeField] private Image _barrierFill;
    
    public void SetHPFill(ConditionChangeArgs args)
    {
        if(args.IsHp)
            _hpFill.fillAmount = CalcRate(args.CurrentValue, args.MaxValue);
    }
    public void SetBarrierFill(ConditionChangeArgs args)
    {
        if(!args.IsHp)
            _barrierFill.fillAmount = CalcRate(args.CurrentValue, args.MaxValue);
    }
    private float CalcRate(int current, int max) => (float)current / max;
}
