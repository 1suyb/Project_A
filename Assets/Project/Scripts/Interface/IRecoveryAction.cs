
public interface IRecoveryAction
{
    public void Apply(Condition condition);
}

/// <summary>
/// 고정 값 회복
/// </summary>
public class FixedRecovery : IRecoveryAction
{
    private int _value;
    public FixedRecovery(int value)
    {
        _value = value;
    }
    
    public void Apply(Condition condition)
    {
        condition.Add(_value);
    }
}

/// <summary>
/// 퍼센트 회복
/// </summary>
public class PercentRecovery : IRecoveryAction
{
    private float _percent;

    public PercentRecovery(float percent)
    {
        _percent = percent;
    }

    public void Apply(Condition condition)
    {
        condition.Add((int)(condition.MaxCondition * _percent));
    }
}

public interface IAutoRecoveryPolicy
{
    float Interval { get; }
    int Amount { get; }
}

public class NoAutoRecoveryPolicy : IAutoRecoveryPolicy
{
    public float Interval => 0;
    public int Amount => 0;
}

public class AutoRecoveryPolicy : IAutoRecoveryPolicy
{
    public float Interval { get; private set; }
    public int Amount { get; private set; }
    public AutoRecoveryPolicy(float interval, int amount)
    {
        Interval = interval;
        Amount = amount;
    }
    
}