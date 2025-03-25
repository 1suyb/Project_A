using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Option
{
    protected OptionInfo _optionInfo;

    public void SetOptionInfo(OptionInfo optionInfo)
    {
        _optionInfo = optionInfo;
    }
    public abstract void Apply(Status status);
    public abstract void Remove(Status status);
}

public static class OptionFactory
{
    private static Dictionary<OptionType, Option> optionsDic = new Dictionary<OptionType, Option>();
    public static Option CreateOption(OptionInfo optionInfo)
    {
        Option option = null;
        if ((int)optionInfo.OptionType < 10)
        {
            option = new StatOption();
            option.SetOptionInfo(optionInfo);
        }

        return option;
    }
}

