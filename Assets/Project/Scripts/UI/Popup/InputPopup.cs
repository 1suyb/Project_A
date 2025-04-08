using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InputPopup : UI
{
    [SerializeField] private TMP_Text _message;
    [SerializeField] private TMP_InputField _inputField;
    [SerializeField] private Button _yButton;
    [SerializeField] private Button _nButton;
    
    private void CloseButtonSetup()
    {
        _nButton.onClick.AddListener(() =>
        {
            UIManager.Popup.CloseUI(this);
        });
    }
    public void SetPopup(string message, System.Action<string> onYes)
    {
        _inputField.contentType = TMP_InputField.ContentType.Standard;
        _message.text = message;
        _yButton.onClick.AddListener(() =>
        {
            onYes?.Invoke(_inputField.text);
            UIManager.Popup.CloseUI(this);
        });
        CloseButtonSetup();
    }
    public void SetPopup(string message, System.Action<int> onYes)
    {
        _inputField.contentType = TMP_InputField.ContentType.IntegerNumber;
        _message.text = message;
        _yButton.onClick.AddListener(() =>
        {
            onYes?.Invoke(int.Parse(_inputField.text));
            UIManager.Popup.CloseUI(this);
        });
        CloseButtonSetup();
    }
}