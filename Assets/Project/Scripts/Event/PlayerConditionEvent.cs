

public struct HealEvent
{
    public int value;
    public bool isOverHeal;
    public HealEvent(int value, bool isOverHeal)
    {
        this.value = value;
        this.isOverHeal = isOverHeal;
    }
}