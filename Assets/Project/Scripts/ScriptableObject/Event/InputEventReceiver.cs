using System;
using UnityEngine;

[CreateAssetMenu(fileName = "InputEventReceiver", menuName = "ScriptableObjects/Events/InputEventReceiver")]
public class InputEventReceiver : ScriptableObject
{
    public event Action OnTouchBegan;
    public event Action OnTouchStationary;
    public event Action OnTouchMoved;
    public event Action OnTouchEnded;
    
    public void TouchBegan()
    {
        OnTouchBegan?.Invoke();
    }
    public void TouchStationary()
    {
        OnTouchStationary?.Invoke();
    }
    public void TouchMoved()
    {
        OnTouchMoved?.Invoke();
    }
    public void TouchEnded()
    {
        OnTouchEnded?.Invoke();
    }
    
}
