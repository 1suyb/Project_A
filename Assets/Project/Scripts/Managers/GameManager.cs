public class GameManager : Singleton<GameManager>
{
    public Character Character { get; private set; }
    public Monster Monster;
    protected override void InitOnCreate()
    {
    }
    
}