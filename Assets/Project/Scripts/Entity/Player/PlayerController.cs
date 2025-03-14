using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private InputEventReceiver _inputEventReceiver;
    
    public Player Player { get; private set; }
    
    private PlayerAttackAct _attackAct;
    private PlayerDefenseAct _defenseAct;
    
    public void InitOnCreate(Player player)
    {
        if(_inputEventReceiver == null)
            _inputEventReceiver = ResourceLoader.Load<InputEventReceiver>(Path.SO.InputEventReceiver);
        
        Player = player;
        
        _attackAct = new PlayerAttackAct(this);
        _defenseAct = new PlayerDefenseAct(this);
        
        if(_inputEventReceiver == null)
            return;
        _inputEventReceiver.OnTouchMoved += _attackAct.Execute;
        _inputEventReceiver.OnTouchStationary += _defenseAct.Execute;
        _inputEventReceiver.OnTouchEnded += _attackAct.Undo;
        _inputEventReceiver.OnTouchEnded += _defenseAct.Undo;
    }

    public void Release()
    {
        if(_inputEventReceiver == null)
            return;
        _inputEventReceiver.OnTouchMoved -= _attackAct.Execute;
        _inputEventReceiver.OnTouchStationary -= _defenseAct.Execute;
        _inputEventReceiver.OnTouchEnded -= _attackAct.Undo;
        _inputEventReceiver.OnTouchEnded -= _defenseAct.Undo;
    }
    
    
}