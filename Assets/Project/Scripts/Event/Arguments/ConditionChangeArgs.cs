public struct ConditionChangeArgs
{
    public int CurrentValue;
    public int MaxValue;
    public bool IsHp;
    
    public ConditionChangeArgs(int maxValue, int currentValue, bool isHp)
    {
        MaxValue = maxValue;
        CurrentValue = currentValue;
        IsHp = isHp;
    }
}