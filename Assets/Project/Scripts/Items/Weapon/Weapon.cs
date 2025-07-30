using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private Character _character;

    public void SetPlayer(Character character)
    {
        _character = character;
    }
    public void Attack()
    {
        AttackHandler attackHandler = new AttackHandler(_character.CharacterStatHandler.Stat, 100, new FixedDamage());
        GameManager.Instance.Monster.TakeDamage(attackHandler);
    }
}