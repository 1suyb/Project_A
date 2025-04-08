public class HUDManager : UIManagerBase
{
    public MonsterConditonHUD MonsterConditionHUD { get; private set; }
    public PlayerConditionHUD PlayerConditionHUD { get; private set; }
    
    public void Init()
    {
        MonsterConditionHUD = GetComponentInChildren<MonsterConditonHUD>();
        PlayerConditionHUD = GetComponentInChildren<PlayerConditionHUD>();
    }
}