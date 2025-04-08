using UnityEngine;

public class RoundData
{
    public RoundType RoundType { get; private set; }
    private int _maxValue;
    private int _minValue;
    public int Value => Random.Range(_minValue, _maxValue);
    
    public RoundData(RoundType roundType, int maxValue, int minValue)
    {
        RoundType = roundType;
        _maxValue = maxValue;
        _minValue = minValue;
    }
    
}