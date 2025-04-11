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

    private void Awake()
    {
        _Ybutton.onClick.AddListener(() =>
        {
            UIManager.Popup.CloseUI(this);
        });
        _Nbutton.onClick.AddListener(() =>
        {
            UIManager.Popup.CloseUI(this);
        });
    }
    
    public void SetPopup(string message, Action onYes, Action onNo = null)
    {
        _message.text = message;
        _Ybutton.onClick.AddListener(() =>
        {
            onYes?.Invoke();
        });
        if (onNo == null)
        {
            _Nbutton.onClick.AddListener(() =>
            {
                onNo?.Invoke();
            });
        }
    }
    public void SetPopup(string title, string message, Action onYes, Action onNo = null)
    {
        _title.text = title;
        _message.text = message;
        _Ybutton.onClick.AddListener(() =>
        {
            onYes?.Invoke();
        });
        _Nbutton.onClick.AddListener(() =>
        {
            onNo?.Invoke();
        });
    }
}