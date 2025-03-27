using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Path
{
    public static string Monster(int id){ return "Prefabs/Monster/" + id; }
    public static string EquipModel(int id){return "Prefabs/Equipments/Model/" + id;}
    
    public class SO
    {
        public static string InputEventReceiver = "ScriptableObjects/Events/InputEventReceiver";
        public static string PlayerEventReceiver = "ScriptableObjects/Events/PlayerEventReceiver";
    }
    public static Dictionary<UIType,string> UI = new Dictionary<UIType, string>
    {
        {UIType.HUD, "Prefabs/UI/HUD/"},
    };
}
