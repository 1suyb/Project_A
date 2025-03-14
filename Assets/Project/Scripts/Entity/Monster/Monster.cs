using UnityEngine;

public class Monster : MonoBehaviour, ILoadable
{
    private MonsterInfo _monsterInfo;
    public MonsterInfo MonsterInfo => _monsterInfo;
    
    public MonsterAnimationController MonsterAnimController { get; private set; }
    public MonsterAI MonsterAI { get; private set; }
    public MonsterPrefab MonsterPrefab { get; private set; }

    public void Awake()
    {
        Load(1);
    }

    public void Load(int id)
    {
        _monsterInfo = InfoManager.Instance.Load<MonsterInfo>(id);
        GameObject prefab = ResourceLoader.Instantiate(Path.Monster(id), this.transform);

        MonsterAnimController = GetComponent<MonsterAnimationController>();
        MonsterAI = GetComponent<MonsterAI>();
        MonsterPrefab = prefab.GetComponent<MonsterPrefab>();
        
        
        MonsterAnimController.InitOnCreate();
        MonsterAI.InitOnCreate(this);
        MonsterPrefab.InitOnCreate(this);
        
        InitOnActivate();
    }

    public void InitOnActivate()
    { 
        MonsterAI.InitOnActivate();
        MonsterPrefab.InitOnActivate();
    }
    
}

public class MonsterStatus
{
    public StatHandler StatHandler { get; private set; }
    public ConditionHandler ConditionHandler { get; private set; }
    
    
}