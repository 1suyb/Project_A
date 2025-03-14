public class Stat
{
    public int Hp { get; private set; }
    public int Barrier{ get; private set; }
    public int BarrierBonusAttack{ get; private set; }
    public int Attack{ get; private set; }
    public int CriticalChance{ get; private set; } // 만분율

    public Stat(){}
    public Stat(int hp, int barrier, int barrierBonusAttack, int attack, int criticalChance)
    {
        Hp = hp;
        Barrier = barrier;
        BarrierBonusAttack = barrierBonusAttack;
        Attack = attack;
        CriticalChance = criticalChance;
    }

    public Stat(Stat stat)
    {
        Copy(stat);
    }

    public void Reset()
    {
        Hp = 0;
        Barrier = 0;
        BarrierBonusAttack = 0;
        Attack = 0;
        CriticalChance = 0;
    }

    public void Copy(Stat stat)
    {
        Hp = stat.Hp;
        Barrier = stat.Barrier;
        BarrierBonusAttack = stat.BarrierBonusAttack;
        Attack = stat.Attack;
        CriticalChance = stat.CriticalChance;
    }
    
    public void Add(Stat stat)
    {
        Hp += stat.Hp;
        Barrier += stat.Barrier;
        BarrierBonusAttack += stat.BarrierBonusAttack;
        Attack += stat.Attack;
        CriticalChance += stat.CriticalChance;
    }
    public void Sub(Stat stat)
    {
        Hp -= stat.Hp;
        Barrier -= stat.Barrier;
        BarrierBonusAttack -= stat.BarrierBonusAttack;
        Attack -= stat.Attack;
        CriticalChance -= stat.CriticalChance;
    }

    public void Multiple(Stat stat)
    {
        Hp += (stat.Hp+100)/100;
        Barrier += (stat.Barrier+100)/100;
        BarrierBonusAttack += (stat.BarrierBonusAttack+100)/100;
        Attack += (stat.Attack+100)/100;
        CriticalChance += (stat.CriticalChance+100)/100;
    }
    
    public static Stat operator +(Stat rightSide, Stat leftSide)
    {
        Stat result = new Stat(rightSide);
        result.Add(leftSide);
        return result;
    }
    public static Stat operator -(Stat rightSide, Stat leftSide)
    {
        Stat result = new Stat(rightSide);
        result.Sub(leftSide);
        return result;
    }
}