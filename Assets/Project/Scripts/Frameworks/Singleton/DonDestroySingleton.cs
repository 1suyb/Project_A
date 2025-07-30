using System;
using UnityEngine;

public class DonDestroySingleton<T> : Singleton<T> where T : DonDestroySingleton<T>
{
    protected sealed override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }
}