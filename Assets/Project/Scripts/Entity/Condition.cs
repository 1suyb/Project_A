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
            ChangeEvent?.Invoke(new ConditionChangeArgs(MaxCondition, _conditionValue, _isHp));
        }
    }

    private bool _isHp;
    public bool IsDie => ConditionValue <= 0;
    
    public Action<ConditionChangeArgs> ChangeEvent;
    
    public Condition(){}

    public Condition(int maxCondition, bool isHp = true)
    {
        _isHp = isHp;
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
    /// <summary>
    /// ConditionValue에서 value만큼 뺀 값을 반환합니다.
    /// 음수인경우 ConditionValue는 0으로 저장되지만, 음수도 반환합니다.
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public int Sub(int value)
    {
        int result = _conditionValue - value;
        ConditionValue -= value;
        return result;
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
    public static bool operator >(Condition condition, int value)
    {
        return condition.ConditionValue > value;
    }
    
    public static bool operator <(Condition condition, int value)
    {
        return condition.ConditionValue < value;
    }
}