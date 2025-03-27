using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManagerBase : MonoBehaviour
{
    protected Stack<UI> _uiStack = new Stack<UI>();
    protected Dictionary<UIType, UI> _uiDict = new Dictionary<UIType, UI>();
    
    public virtual T GetUI<T>(UIType uiType) where T : UI
    {
        T ui;
        if(_uiDict.ContainsKey(uiType))
        {
            ui = _uiDict[uiType] as T;
        }
        else
        {
            ui = ResourceLoader.Load<T>(Path.UI[uiType]);
            _uiDict.Add(uiType, ui);
            ui.gameObject.SetActive(false);
        }

        return ui;
    }
    
    public virtual T OpenUI<T>(UIType uiType) where T : UI
    {
        T ui = GetUI<T>(uiType);
        ui.Open();
        _uiStack.Push(ui);
        return ui;
    }
    
    public virtual void CloseUI<T>(UIType uiType) where T : UI
    {
        T ui = GetUI<T>(uiType);
        if(_uiStack.Peek()==ui)
        {
            CloseTopUI();
        }
    }
    
    public virtual void CloseTopUI()
    {
        if(_uiStack.Count>0)
        {
            UI ui = _uiStack.Pop();
            ui.Close();
        }
    }
    
    public virtual void CloseAllUI()
    {
        while(_uiStack.Count>0)
        {
            CloseTopUI();
        }
    }
}

public class PopupManager: UIManagerBase
{
    
}

public class WindowManager : UIManagerBase
{
    
}

public class FloatingManager : UIManagerBase
{
    
}