public class FactoryManager : Singleton<FactoryManager>
{
    private MonsterPoolFactory _monsterPoolFactory;
    public static MonsterPoolFactory MonsterPoolFactory => Instance._monsterPoolFactory;

    protected void InitOnCreate()
    {
        _monsterPoolFactory = new MonsterPoolFactory();
        MonsterPoolFactory.Init();
    }
}