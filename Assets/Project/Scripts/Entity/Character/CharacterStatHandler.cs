using System;

public class CharacterStatHandler : StatHandler
{
    private Character _character;
    public CharacterStatHandler(Entity entity) : base(entity)
    {
        _character = entity as Character;
        if (_character == null)
        {
            throw new Exception("Entity is not Character");
        }
    }

    protected override Stat BaseStat()
    {
        //Todo : 나중에 CharacterInfo로 바꿔야함
        return new StatBuilder().Hp(3).Attack(1).Build();
    }
}