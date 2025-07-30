public interface IDamageAction
{
    public void Apply(Condition barrier, Condition hp, int damage);
}


/// <summary>
/// 고정 값 데미지
/// </summary>
public class FixedDamage : IDamageAction
{
     
    public void Apply(Condition barrier, Condition hp, int damage)
    {
        if(barrier.ConditionValue > 0)
        {
            if(barrier>0)
            {
                damage = -barrier.Sub(damage);
            }
            if(damage <= 0)
            {
                return;
            }
            hp.Sub(damage);
        }
    }
}
/// <summary>
/// 퍼센트 hp 데미지
/// </summary>
public class HpPercentDamage : IDamageAction
{
    public void Apply(Condition barrier, Condition hp, int damage)
    {
        hp.Sub((int)(hp.MaxCondition * damage));
    }
}
/// <summary>
/// 퍼센트 barrier 데미지
/// </summary>
public class BarrierPercentDamage : IDamageAction
{
    public void Apply(Condition barrier, Condition hp, int damage)
    {
        barrier.Sub((int)(barrier.MaxCondition * damage));
    }
}
/// <summary>
/// 고정 값 barrier 데미지
/// </summary>
public class BarrierFixedDamage : IDamageAction
{
    public void Apply(Condition barrier, Condition hp, int damage)
    {
        if(barrier.ConditionValue > 0)
        {
            barrier.Sub(damage);
        }
    }
}
/// <summary>
/// 고정값 hp 데미지
/// </summary>
public class HpFixedDamage : IDamageAction
{
    public void Apply(Condition barrier, Condition hp, int damage)
    {
        hp.Sub(damage);
    }
}