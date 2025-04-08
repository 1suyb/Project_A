using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ConfirmPopup : UI
{
    [SerializeField] private TMP_Text _title;
    [SerializeField] private TMP_Text _message;
    
    [SerializeField] private TMP_Text _Ytext;
    [SerializeField] private TMP_Text _Ntext;
    
    [SerializeField] private Button _Ybutton;
    [SerializeField] private Button _Nbutton;

    private void CloseButtonSetup()
    {
        _Nbutton.onClick.AddListener(() =>
        {
            UIManager.Popup.CloseUI(this);
        });
    }
    public void SetPopup(string message, Action onYes)
    {
        _message.text = message;
        _Ybutton.onClick.AddListener(() =>
        {
            onYes?.Invoke();
            UIManager.Popup.CloseUI(this);
        });
        CloseButtonSetup();
    }
    public void SetPopup(string title, string message, Action onYes)
    {
        _title.text = title;
        _message.text = message;
        _Ybutton.onClick.AddListener(() =>
        {
            onYes?.Invoke();
            UIManager.Popup.CloseUI(this);
        });
        CloseButtonSetup();
    }
}