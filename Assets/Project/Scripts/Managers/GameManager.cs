public class GameManager : Singleton<GameManager>
{
    public Player Player { get; private set; }
    public Monster Monster;
    protected override void Awake()
    {
        base.Awake();
        InitOnCreate();
    }
    
    public void InitOnCreate()
    {
        Player = FindObjectOfType<Player>();
        Player.InitOnCreate();
    }

    private void Start()
    {
        Player.InitOnActivate();
    }
}