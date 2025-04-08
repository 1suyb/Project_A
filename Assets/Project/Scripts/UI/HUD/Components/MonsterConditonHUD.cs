using TMPro;
using UnityEngine;

public class MonsterConditonHUD : HUD
{
    private Monster _monster;
    [SerializeField] private ConditionHUD _monsterConditon;
    [SerializeField] private TMP_Text _monsterName;
    
    /// <summary>
    /// 몬스터의 정보를 HUD에 등록합니다.
    /// </summary>
    /// <param name="monster"></param>
    public void RegisterMonster(Monster monster)
    {
        _monster = monster;
        monster.AddChangeBarrierEvent(_monsterConditon.SetBarrierFill);
        monster.AddChangeHpEvent(_monsterConditon.SetHPFill);
        monster.AddDieEvent(UnRegisterMonster);
        
        int monsterNameID = monster.MonsterInfo.NameID;
        // Todo : Load monster name from StringManager 
        _monsterName.text = InfoManager.Instance.Load<LocalizedString>(monsterNameID).Eng;
    }
    /// <summary>
    /// 몬스터의 정보를 HUD에서 제거합니다.
    /// 몬스터 사망시 자동 실행 됩니다.
    /// </summary>
    public void UnRegisterMonster()
    {
        _monster.RemoveChangeBarrierEvent(_monsterConditon.SetBarrierFill);
        _monster.RemoveChangeHpEvent(_monsterConditon.SetHPFill);
        _monster.RemoveDieEvent(UnRegisterMonster);
    }
}
