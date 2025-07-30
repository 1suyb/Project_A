using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    public static HUDManager HUD => Instance._hudManager;
    public static PopupManager Popup => Instance._popupManager;
    public static WindowManager Window => Instance._windowManager;
    public static FloatingManager Floating => Instance._floatingManager;

    private HUDManager _hudManager;
    private PopupManager _popupManager;
    private WindowManager _windowManager;
    private FloatingManager _floatingManager;

    protected override void InitOnCreate()
    {
        _hudManager = GetComponentInChildren<HUDManager>();
        _hudManager.Init();
        _popupManager = GetComponentInChildren<PopupManager>();
        _windowManager = GetComponentInChildren<WindowManager>();
        _floatingManager = GetComponentInChildren<FloatingManager>();
    }

}
