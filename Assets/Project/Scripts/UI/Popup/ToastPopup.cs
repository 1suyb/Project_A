using TMPro;
using UnityEngine;

public class ToastPopup : UI
{
    [SerializeField] private TMP_Text _message;
    private float _lifeTime;
    public void SetPopup(string message, float lifeTime = 2f)
    {
        _message.text = message;
        _lifeTime = lifeTime;
        Invoke(nameof(TimeOut), _lifeTime);
    }

    private void TimeOut()
    {
        UIManager.Popup.CloseUI(this);
    }
}