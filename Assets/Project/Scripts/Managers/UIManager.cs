using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    public HUDManager HUD { get; private set; }
    public PopupManager Popup { get; private set; }
    public WindowManager Window { get; private set; }
    public FloatingManager Floating { get; private set; }
    
}
