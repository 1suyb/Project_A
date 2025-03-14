using UnityEngine;

public class Monster : MonoBehaviour, ILoadable
{
    private MonsterInfo _monsterInfo;
    public MonsterInfo MonsterInfo => _monsterInfo;
    
    public MonsterAnimationController MonsterAnimController { get; private set; }
    public MonsterAI MonsterAI { get; private set; }
    public MonsterPrefab MonsterPrefab { get; private set; }

    public MonsterStatus MonsterStatus { get; private set; }
    
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
        MonsterStatus = GetComponent<MonsterStatus>();
        MonsterPrefab = prefab.GetComponent<MonsterPrefab>();
        
        
        MonsterAnimController.InitOnCreate();
        MonsterAI.InitOnCreate(this);
        MonsterStatus.InitOnCreate(this);
        MonsterPrefab.InitOnCreate(this);
        
        InitOnActivate();
    }

    public void InitOnActivate()
    { 
        MonsterAI.InitOnActivate();
        MonsterStatus.InitOnActivate();
        MonsterPrefab.InitOnActivate();
    }
    
    public void TakeDamage(int damage)
    {
        MonsterStatus.TakeDamage(damage);
        // 쳐맞는 애니메이션
    }
    public void Heal(int heal, bool isOverHeal = false)
    {
        MonsterStatus.Heal(heal, isOverHeal);
        
    }
    
}