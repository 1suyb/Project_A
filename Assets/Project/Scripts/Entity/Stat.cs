public class Stat
{
    public int Hp { get; private set; }
    public int Barrier{ get; private set; }
    public int BarrierBonusAttack{ get; private set; }
    public int Attack{ get; private set; }
    public int AttackSpeed{ get; private set; } // 백분율
    public int CriticalChance{ get; private set; } // 만분율

    public Stat(){}
    public Stat(int hp, int barrier, int barrierBonusAttack, int attack,int attackSpeed, int criticalChance)
    {
        Hp = hp;
        Barrier = barrier;
        BarrierBonusAttack = barrierBonusAttack;
        Attack = attack;
        AttackSpeed = attackSpeed;
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
        AttackSpeed = 0;
        CriticalChance = 0;
    }

    public void Copy(Stat stat)
    {
        Hp = stat.Hp;
        Barrier = stat.Barrier;
        BarrierBonusAttack = stat.BarrierBonusAttack;
        Attack = stat.Attack;
        AttackSpeed = stat.AttackSpeed;
        CriticalChance = stat.CriticalChance;
    }
    
    public void Add(Stat stat)
    {
        Hp += stat.Hp;
        Barrier += stat.Barrier;
        BarrierBonusAttack += stat.BarrierBonusAttack;
        Attack += stat.Attack;
        AttackSpeed += stat.AttackSpeed;
        CriticalChance += stat.CriticalChance;
    }
    public void Sub(Stat stat)
    {
        Hp -= stat.Hp;
        Barrier -= stat.Barrier;
        BarrierBonusAttack -= stat.BarrierBonusAttack;
        Attack -= stat.Attack;
        AttackSpeed -= stat.AttackSpeed;
        CriticalChance -= stat.CriticalChance;
    }

    public void Multiple(Stat stat)
    {
        int radio = 10000;
        Hp *= 1 + stat.Hp/radio;
        Barrier *= 1+ stat.Barrier/radio;
        BarrierBonusAttack *= 1+ stat.BarrierBonusAttack/radio;
        Attack *= 1+ stat.Attack/radio;
        AttackSpeed *= 1+ stat.AttackSpeed/radio;
        CriticalChance *= 1+stat.CriticalChance/radio;
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