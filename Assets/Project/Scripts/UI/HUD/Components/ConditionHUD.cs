using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConditionHUD : HUD
{
    [SerializeField] private Image _hpFill;
    [SerializeField] private Image _barrierFill;
    
    public void SetHPFill(int current, int max)
    {
        _barrierFill.fillAmount = CalcRate(current, max);
    }
    public void SetBarrierFill(int current, int max)
    {
        _barrierFill.fillAmount = CalcRate(current, max);
    }
    private float CalcRate(int current, int max) => (float)current / max;
}
