using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AlertPopup : UI
{
    [SerializeField] private TMP_Text _message;
    [SerializeField] private Button _closeButton;
    
    private void CloseButtonSetup()
    {
        _closeButton.onClick.AddListener(() =>
        {
            UIManager.Popup.CloseUI(this);
        });
    }
    public void SetPopup(string message)
    {
        _message.text = message;
        CloseButtonSetup();
    }
}