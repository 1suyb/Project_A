using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InputCountPopup : UI
{
    [SerializeField] private TMP_Text _message;
    [SerializeField] private TMP_InputField _inputField;
    
    [SerializeField] private Button _upCount;
    [SerializeField] private Button _downCount;
    [SerializeField] private Button _yButton;
    [SerializeField] private Button _nButton;

    private void Awake()
    {
        _upCount.onClick.AddListener(UpCount);
        _downCount.onClick.AddListener(DownCount);
    }

    private void CloseButtonSetup()
    {
        _nButton.onClick.AddListener(() =>
        {
            UIManager.Popup.CloseUI(this);
        });
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

    private void UpCount()
    {
        _inputField.text = (int.Parse(_inputField.text) + 1).ToString();
    }
    private void DownCount()
    {
        _inputField.text = (int.Parse(_inputField.text) - 1).ToString();
    }
}