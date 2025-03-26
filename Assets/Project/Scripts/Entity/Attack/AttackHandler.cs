public class AttackHandler
{
    private Stat _stat;
    private int _damage;
    public AttackHandler(Stat stat, int damage)
    {
        _stat = stat;
        _damage = damage;
    }
    public int CalcDamage(Stat stat)
    {
        return _damage;
    }
}