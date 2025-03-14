using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipments : MonoBehaviour
{
    private Player _player;
    
    public Weapon Weapon { get; private set; }
    public Shield Shield { get; private set; }
    
    public void InitOnCreate(Player player)
    {
        _player = player;
    }
    
    /*public void Equip(Equipment equipment)
    {
        if(equipment is Weapon)
        {
            Weapon = equipment as Weapon;
            Weapon.Equip();
        }
        else if(equipment is Shield)
        {
            Shield = equipment as Shield;
            Shield.Equip();
        }
    }*/
    
}
