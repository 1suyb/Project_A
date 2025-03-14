public class StatBuilder
{
    private int _hp = 0;
    private int _barrier = 0;
    private int _barrierBonusAttack = 0;
    private int _attack = 0;
    private int _criticalChance = 0;
    
    public StatBuilder Hp(int hp)
    {
        _hp = hp;
        return this;
    }
    public StatBuilder Barrier(int barrier)
    {
        _barrier = barrier;
        return this;
    }
    public StatBuilder BarrierBonusAttack(int barrierBonusAttack)
    {
        _barrierBonusAttack = barrierBonusAttack;
        return this;
    }
    public StatBuilder Attack(int attack)
    {
        _attack = attack;
        return this;
    }
    public StatBuilder CriticalChance(int criticalChance)
    {
        _criticalChance = criticalChance;
        return this;
    }
    public Stat Build()
    {
        return new Stat(_hp, _barrier, _barrierBonusAttack, _attack, _criticalChance);
    }
}