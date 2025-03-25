using System.Collections.Generic;
using UnityEngine;

public class Equipment : Item
{
    public EquipmentInfo EquipmentInfo { get; private set; }
    public List<Option> Options { get; private set; }
    private PlayerEventReceiver _playerEventReceiver;
    private bool _isEquiped;

    public Equipment(int id)
    {
        InitEventReceiver();
        InitEquipInfo(id);
        InitOption();
    }

    /// <summary>
    /// EquipInfo 할당
    /// </summary>
    /// <param name="id"></param>
    private void InitEquipInfo(int id)
    {
        InfoLoader<EquipmentInfo> equipLoader = InfoManager.Instance.GetInfoLoader<EquipmentInfo>();
        EquipmentInfo = equipLoader.Load(id);
    }
    /// <summary>
    /// Options 초기화 할당
    /// </summary>
    private void InitOption()
    {
        InfoLoader<OptionInfo> optionLoader = InfoManager.Instance.GetInfoLoader<OptionInfo>();
        List<int> options = EquipmentInfo.OptionIDs;
        Options = new List<Option>();
        for(int i = 0 ; i<options.Count; i++)
        {
            OptionInfo optionInfo = optionLoader.Load(options[i]);
            Options.Add(OptionFactory.CreateOption(optionInfo));
        }
    }
    
    /// <summary>
    /// Player event receiver 할당
    /// </summary>
    public void InitEventReceiver()
    {
        _playerEventReceiver = EventHub.PlayerEventReceiver;
        
        #if UNITY_EDITOR
        if (_playerEventReceiver == null)
        {
            Debug.LogError("PlayerEventReceiver is null. 이벤트 리시버가 제대로 초기화되지 않았습니다.");
        }
        #endif
    }
    
    public override void Use()
    {
        if(_isEquiped)
        {
            UnEquip();
        }
        else
        {
            Equip();
        }

    }

    private void UnEquip()
    {
        _playerEventReceiver.UnEquip(this);
        _isEquiped = false;
    }

    private void Equip()
    {
        _playerEventReceiver.Equip(this);
        _isEquiped = true;
    }
}