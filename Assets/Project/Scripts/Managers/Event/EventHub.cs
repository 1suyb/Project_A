using UnityEngine;

public static class EventHub
{
    private static PlayerEventReceiver _playerEventReceiver;

    public static PlayerEventReceiver PlayerEventReceiver
    {
        get
        {
            if (_playerEventReceiver == null)
            {
                _playerEventReceiver = Resources.Load<PlayerEventReceiver>(Path.SO.PlayerEventReceiver);
#if UNITY_EDITOR
                if (_playerEventReceiver == null)
                {
                    Debug.LogError("PlayerEventReceiver not found in Resources/ScriptableObjects/");
                }
#endif
            }
            return _playerEventReceiver;
        }
    }
}