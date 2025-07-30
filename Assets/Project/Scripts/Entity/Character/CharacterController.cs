using System;
using UnityEngine;
using UnityEngine.Serialization;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private InputEventReceiver _inputEventReceiver;
    [FormerlySerializedAs("PlayerState")] public CharacterState characterState;
    public Character Character { get; private set; }
    
    private PlayerAttackAct _attackAct;
    private PlayerDefenseAct _defenseAct;
    
    public void InitOnCreate(Character character)
    {
        if(_inputEventReceiver == null)
            _inputEventReceiver = ResourceLoader.Load<InputEventReceiver>(Path.SO.InputEventReceiver);
        
        Character = character;
        
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