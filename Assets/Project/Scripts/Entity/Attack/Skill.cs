public class Skill
{
    protected SkillInfo _skillInfo;
    protected Stat _stat;
    public Skill(int id, Stat stat)
    {
        InfoLoader<SkillInfo> skillInfoLoader = InfoManager.Instance.GetInfoLoader<SkillInfo>();
        _skillInfo = skillInfoLoader.Load(id);
        _stat = stat;
    }

    public void Execute(IHittable target)
    {
        AttackHandler attackHandler = new AttackHandler(_stat, CalcDamage(),new FixedDamage());
        target.TakeDamage(attackHandler);
    }

    protected void ShootProjectile()
    {
    }
    protected int CalcDamage()
    {
        int damage = (int)(_stat.Attack * (_skillInfo.DamageRate / 100f + 1));
        return damage;
    }
}