public class StatOption : Option
{
    private Stat _stat;
    public override void Apply(Status status)
    {
        switch (_optionInfo.OptionType)
        {
            case OptionType.Attack:
                _stat = new StatBuilder().Attack(_optionInfo.Value).Build();
                status.ModifyStat(_stat,!_optionInfo.IsPercent);
                break;
            case OptionType.AttackSpeed:
                _stat = new StatBuilder().AttackSpeed(_optionInfo.Value).Build();
                status.ModifyStat(_stat,false);
                break;
            case OptionType.Barrier:
                _stat = new StatBuilder().Barrier(_optionInfo.Value).Build();
                status.ModifyStat(_stat,!_optionInfo.IsPercent);
                break;
            case OptionType.BarrierBonusAttack:
                _stat = new StatBuilder().BarrierBonusAttack(_optionInfo.Value).Build();
                status.ModifyStat(_stat,!_optionInfo.IsPercent);
                break;
            case OptionType.CriticalChance:
                _stat = new StatBuilder().CriticalChance(_optionInfo.Value).Build();
                status.ModifyStat(_stat,false);
                break;
        }
    }

    public override void Remove(Status status)
    {
        status.RemoveStatModifier(_stat);
    }
}