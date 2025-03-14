using System;
using UnityEngine;

public class Condition
{
    private int _maxCondition;

    public int MaxCondition
    {
        get => _maxCondition;
        set
        {
            ConditionValue += value -  _maxCondition;
            _maxCondition = value;
        }
    }

    private int _conditionValue;

    public int ConditionValue
    {
        get => _conditionValue;
        set
        {
            _conditionValue = value > 0 ? value : 0;
            ChangeEvent?.Invoke(_conditionValue);
        }
    }
    
    public bool IsDie => ConditionValue <= 0;

    public Action<int> ChangeEvent;
    
    public Condition(){}

    public Condition(int maxCondition)
    {
        MaxCondition = maxCondition;
        ConditionValue = maxCondition;
    }
    
    public Condition(Condition condition)
    {
        MaxCondition = condition.MaxCondition;
        ConditionValue = condition.ConditionValue;
    }
    
    public void Add(int value, bool isOverHeal = false)
    {
        if (isOverHeal)
        {
            ConditionValue += value;
        }
        else
        {
            ConditionValue = Mathf.Min(MaxCondition, ConditionValue + value);
        }
    }
    public void Sub(int value)
    {
        ConditionValue -= value;
    }
    
    public static Condition operator +(Condition condition, int value)
    {
        Condition result = new Condition(condition);
        result.ConditionValue += value;
        return result;
    }
    public static Condition operator -(Condition condition, int value)
    {
        Condition result = new Condition(condition);
        result.ConditionValue -= value;
        return result;
    }
}