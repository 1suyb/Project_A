using System;
using System.Collections.Generic;
using UnityEngine;


public class Condition
{
    private int _maxCondition;
    public int MaxCondition
    {
        get => _maxCondition;
        set
        {
            ConditionValue = Mathf.Max(ConditionValue + (value - _maxCondition), 1);
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
            OnChange?.Invoke(_maxCondition, _conditionValue);
        }
    }
    
    private IAutoRecoveryPolicy _autoRecoveryPolicy;
    private int _autoRecoveryRoutineId;
    public bool IsDie => ConditionValue <= 0;
    
    public Action<int,int> OnChange;
    public Action OnExhausted;
    public Condition(int maxCondition, IAutoRecoveryPolicy autoRecoveryPolicy)
    {
        _autoRecoveryPolicy = autoRecoveryPolicy;   
        MaxCondition = maxCondition;
        ConditionValue = maxCondition;
        RegisterRecoveryRoutine();
    }
    
    public Condition(Condition condition, IAutoRecoveryPolicy autoRecoveryPolicy)
    {
        _autoRecoveryPolicy = autoRecoveryPolicy;
        MaxCondition = condition.MaxCondition;
        ConditionValue = condition.ConditionValue;
        RegisterRecoveryRoutine();
    }

    public void Release()
    {
        UnregisterRecoveryRoutine();
    }
    
    private void RegisterRecoveryRoutine()
    {
        RoutineManager routineManager = RoutineManager.Instance;
        _autoRecoveryRoutineId = routineManager.StartTurnRoutine(RecoveryRoutine);
    }
    public void UnregisterRecoveryRoutine()
    {
        RoutineManager routineManager = RoutineManager.Instance;
        routineManager.StopTurnRoutine(_autoRecoveryRoutineId);
    }
    
    private void RecoveryRoutine(int turn)
    {
        if(turn % _autoRecoveryPolicy.Interval == 0)
        {
            ConditionValue += _autoRecoveryPolicy.Amount;
        }
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
        Condition result = new Condition(condition, condition._autoRecoveryPolicy);
        result.ConditionValue += value;
        return result;
    }
    public static Condition operator -(Condition condition, int value)
    {
        Condition result = new Condition(condition, condition._autoRecoveryPolicy);
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