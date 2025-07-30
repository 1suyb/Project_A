public class AttackHandler
{
    private Stat _stat;
    private int _damage;
    private IDamageAction _damageAction;
    public AttackHandler(Stat stat, int damage, IDamageAction damageAction)
    {
        _stat = stat;
        _damage = damage;
        _damageAction = damageAction;
    }
    public void ApplyDamage(Condition barrier, Condition hp, Stat stat)
    {
        _damageAction.Apply(barrier, hp, CalcDamage(stat));
    }

    public int CalcDamage(Stat stat)
    {
        return _damage;
    }
}