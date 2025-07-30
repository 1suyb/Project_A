using System;
using System.Collections.Generic;

public enum StatModifyType
{
    Plus,
    Multiplier,
    Remove
}

public abstract class StatHandler
{
    private Entity _entity;
    
    public Stat Stat { get; private set; }
    private Stat _baseStat;
    private Stat _increasedStat => Stat - _baseStat;
    
    private List<Stat> _addModifier = new List<Stat>();
    private List<Stat> _multiplierModifier = new List<Stat>();
    
    public event Action<Stat> OnChange;

    public StatHandler(Entity entity)
    {
        _entity = entity;
        _baseStat = BaseStat();
        Stat = new Stat();
        Stat.Reset();
        Stat.Copy(_baseStat);

    }

    protected abstract Stat BaseStat();

    public void ApplyModifer(Stat stat, StatModifyType statModifyType )
    {
        switch (statModifyType)
        {
            case StatModifyType.Plus:
                AddPlusModifier(stat);
                break;
            case StatModifyType.Multiplier:
                AddMultiplierModifier(stat);
                break;
            case StatModifyType.Remove:
                RemoveModifier(stat);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(statModifyType), statModifyType, null);
        }
        OnChange?.Invoke(Stat);
    }
    
    
    private void AddPlusModifier(Stat stat)
    {
        _addModifier.Add(stat);
        Modify();
    }
    private void AddMultiplierModifier(Stat stat)
    {
        _multiplierModifier.Add(stat);
        Modify();
    }
    private void Modify()
    {
        Stat.Reset();
        Stat.Copy(_baseStat);
        foreach (var stat in _addModifier)
        {
            Stat.Add(stat);
        }
        foreach (var stat in _multiplierModifier)
        {
            Stat.Multiple(stat);
        }
        OnChange?.Invoke(Stat);
    }
    private void RemoveModifier(Stat stat)
    {
        if (_addModifier.Contains(stat))
        {
            _addModifier.Remove(stat);
            Modify();
        }
        else if (_multiplierModifier.Contains(stat))
        {
            _multiplierModifier.Remove(stat);
            Modify();
        }
    }
}