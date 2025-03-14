using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public void Attack()
    {
        Debug.Log($"무기 공격!");
    }
}

public class Shield : MonoBehaviour
{
    public void Defend()
    {
        Debug.Log($"방패 방어!");
    }
}
