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
            ui = ResourceLoader.Instantiate(Path.UI[uiType],this.transform).GetComponent<T>();
            _uiDict.Add(uiType, ui);
            ui.gameObject.SetActive(false);
        }

        return ui;
    }
    
    public virtual T OpenUI<T>(UIType uiType, bool isStack = false) where T : UI
    {
        T ui = GetUI<T>(uiType);
        ui.Open();
        if(isStack)
            _uiStack.Push(ui);

        return ui;
    }
    public virtual UI OpenUI(UI ui, bool isStack = false)
    {
        ui.Open();
        if(isStack)
            _uiStack.Push(ui);
        
        return ui;
    }
    
    public virtual void CloseUI<T>(UIType uiType, bool isStack = false) where T : UI
    {
        T ui = GetUI<T>(uiType);
        if (isStack)
        {
            if(_uiStack.Peek()==ui)
            {
                CloseTopUI();
            }
        }
        else
        {
            ui.Close();
        }
    }
    public virtual void CloseUI(UI ui, bool isStack = false)
    {
        if (isStack)
        {
            if(_uiStack.Peek()==ui)
            {
                CloseTopUI();
            }
        }
        else
        {
            ui.Close();
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

public class WindowManager : UIManagerBase
{
    
}

public class FloatingManager : UIManagerBase
{
    
}