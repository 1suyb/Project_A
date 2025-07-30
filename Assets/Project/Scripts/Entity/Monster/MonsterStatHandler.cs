using System;

public class MonsterStatHandler : StatHandler
{
    private Monster _monster;
    public MonsterStatHandler(Entity entity) : base(entity)
    {
        _monster = entity as Monster;
        if (_monster == null)
        {
            throw new Exception("Entity is not Monster");
        }
    }

    protected override Stat BaseStat()
    {
        MonsterInfo info = _monster.MonsterInfo;
        return new StatBuilder()
            .Hp(info.HP)
            .Barrier(info.Barrier)
            .Attack(info.Attack)
            .Build();
    }
}