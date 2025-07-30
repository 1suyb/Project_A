using System;
using UnityEngine;

public abstract class Round
{
    public RoundData RoundData { get; private set; }
    protected int value => RoundData.Value;
    protected Action OnRoundEnd;
    
    public Round(RoundData roundData, Action action)
    {
        RoundData = roundData;
        OnRoundEnd = action;
    }

    public abstract void Spawn(Transform transform = null);
    
}