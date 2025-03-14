using System.Collections.Generic;

public class StatHandler
{
    public Stat Stat { get; private set; }
    private Stat _baseStat;
    private Stat _increasedStat => Stat - _baseStat;
    
    private List<Stat> _addModifier = new List<Stat>();
    private List<Stat> _multiplierModifier = new List<Stat>();
    
    public StatHandler(Stat stat)
    {
        Stat = new Stat(stat);
        _baseStat = new Stat(stat);
    }
    
    public void AddModifier(Stat stat)
    {
        _addModifier.Add(stat);
        Modify();
    }
    public void AddMultiplierModifier(Stat stat)
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
    }
    
}