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
        this.gameObject.SetActive(true);
        _monsterConditon.Init();
        _monster = monster;
        
        _monster.OnDeath += UnRegisterMonster;
        _monster.OnChangeBarrier += _monsterConditon.SetBarrierFill;
        _monster.OnChangeHp += _monsterConditon.SetHPFill;
        
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
        this.gameObject.SetActive(false);
        _monster.OnDeath -= UnRegisterMonster;
        _monster.OnChangeBarrier -= _monsterConditon.SetBarrierFill;
        _monster.OnChangeHp -= _monsterConditon.SetHPFill;
    }
}
