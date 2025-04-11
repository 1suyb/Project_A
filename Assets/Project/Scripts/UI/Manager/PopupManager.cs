using System;
using UnityEngine;

public class PopupManager: UIManagerBase
{
    public void Confirm(string message, Action onConfirm)
    {
        ConfirmPopup confirmPopup = GetUI<ConfirmPopup>(UIType.ConfirmPopup);
        confirmPopup.SetPopup(message, onConfirm);
        OpenUI(confirmPopup);
    }
    public void EventConfirm(string title, string message, Action onConfirm, Action onClose = null)
    {
        ConfirmPopup confirmPopup = GetUI<ConfirmPopup>(UIType.EventConfirmPopup);
        confirmPopup.SetPopup(title, message, onConfirm, onClose);
        OpenUI(confirmPopup);
        Debug.Log("이벤트 팝업 오픈");
    }

    public void GameOver(Action onConfirm, Action onClose = null)
    {
        ConfirmPopup confirmPopup = GetUI<ConfirmPopup>(UIType.GameOverPopup);
        confirmPopup.SetPopup("GameOver", onConfirm, onClose);
        OpenUI(confirmPopup);
        Debug.Log("게임오버 팝업 오픈");
    }

    /// <summary>
    /// 확인이 필요한 팝업
    /// </summary>
    public void Alert(string message)
    {
        AlertPopup alertPopup = GetUI<AlertPopup>(UIType.AlertPopup);
        alertPopup.SetPopup(message);
        OpenUI(alertPopup);
    }

    /// <summary>
    /// 그냥 내용을 읽기만 해도 되는 메세지
    /// </summary>
    public void Notice(string message)
    {
        AlertPopup alertPopup = GetUI<AlertPopup>(UIType.NoticePopup);
        alertPopup.SetPopup(message);
        OpenUI(alertPopup);
    }

    /// <summary>
    /// 사용자의 입력을 받는 팝업
    /// </summary>
    public void Input(string message, Action<string> onYes)
    {
        InputPopup inputPopup = GetUI<InputPopup>(UIType.InputPopup);
        inputPopup.SetPopup(message, onYes);
        OpenUI(inputPopup);
    }

    /// <summary>
    /// 숫자 입력을 받는 팝업
    /// </summary>
    public void InputCount(string message, System.Action<int> onYes)
    {
        InputPopup inputPopup = GetUI<InputPopup>(UIType.InputCountPopup);
        inputPopup.SetPopup(message, onYes);
        OpenUI(inputPopup);
    }

    /// <summary>
    /// 사용자에게 일시적으로 보여주는 메세지
    /// </summary>
    public void Toast(string message, float lifeTime = 2f)
    {
        ToastPopup toastPopup = GetUI<ToastPopup>(UIType.ToastPopup);
        toastPopup.SetPopup(message, lifeTime);
        OpenUI(toastPopup);
    }
    
    /// <summary>
    /// NPC와 대화 Popup
    /// </summary>
    public void Dialog()
    {
        
    }

    /// <summary>
    /// 툴팁
    /// </summary>
    public void Tooltip()
    {
        
    }
    
    
    
}