using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private Player _player;

    public void SetPlayer(Player player)
    {
        _player = player;
    }
    public void Attack()
    {
        AttackHandler attackHandler = new AttackHandler(_player.PlayerStatus.StatHandler.Stat, 100);
        GameManager.Instance.Monster.TakeDamage(attackHandler);
    }
}