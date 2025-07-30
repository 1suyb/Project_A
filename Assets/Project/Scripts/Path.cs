using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Path
{
    public static string SystemMamanger = "Prefabs/Managers/SystemManager";
    public static string GameManager = "Prefabs/Managers/GameManager";
    public static string Character = "Prefabs/GameScene/Character";
    public static string Camera = "Prefabs/GameScene/MainCam";
    public static string Monster(int id){ return "Prefabs/Monster/" + id; }
    public static string EquipModel(int id){return "Prefabs/Equipments/Model/" + id;}

    public class Base
    {
        public static string Monster = "Prefabs/Stage/Monster";
        public static string Event = "Prefabs/Stage/Event";
    }
    
    public class SO
    {
        public static string InputEventReceiver = "ScriptableObjects/Events/InputEventReceiver";
        public static string PlayerEventReceiver = "ScriptableObjects/Events/PlayerEventReceiver";
    }
    public static Dictionary<UIType,string> UI = new Dictionary<UIType, string>
    {
        {UIType.HUD, "Prefabs/UI/HUD/"},
        {UIType.EventConfirmPopup ,"Prefabs/UI/Popup/EventConfirmPopup"},
        {UIType.GameOverPopup, "Prefabs/UI/Popup/GameOverPopup"},
    };
}
