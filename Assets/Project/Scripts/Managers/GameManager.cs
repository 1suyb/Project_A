public class GameManager : Singleton<GameManager>
{
    public Player Player { get; private set; }
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