using UnityEngine;

public class PlayerStatus : Status
{
    public override void InitOnActivate()
    {
        base.InitOnActivate();
        
        Debug.Log($"StatHandler\n HP : {StatHandler.Stat.Hp} \n Barrier : {StatHandler.Stat.Barrier} \n" +
                  $"Attack : {StatHandler.Stat.Attack} \n BarrierBonusAttack : {StatHandler.Stat.BarrierBonusAttack} \n" +
                  $"CriticalChance : {StatHandler.Stat.CriticalChance}" +
                  $"ConditionHandler\n HP : {ConditionHandler.Hp.ConditionValue}" +
                  $"Barrier : {ConditionHandler.Barrier.ConditionValue}");
    }
    protected override Stat BaseStat()
    {
        return new StatBuilder().Hp(3).Attack(1).Build();
    }
}