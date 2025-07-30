using System;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    private static T _instance;
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
#if UnITY_EDITOR
                Debug.LogError($"Singleton<{typeof(T).Name}> instance is null. "+
                    $"Please check if it is assigned in the scene or created at runtime.");
#endif
                _instance = FindObjectOfType<T>();
                if (_instance == null)
                {
                    Create();
                }
            }
            return _instance;
        }
    }

    protected virtual void Awake()
    {
        if (_instance == null)
        {
            _instance = this as T;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private static void Create()
    {
        GameObject go = new GameObject();
        go.name = typeof(T).Name;
        _instance = go.AddComponent<T>();
        _instance.InitOnCreate();
    }
    public static void Init(Singleton<T> singleton)
    {
        _instance = singleton as T;
        if (_instance == null)
        {
            Create();
        }
        _instance.InitOnCreate();
    }
    protected virtual void InitOnCreate() { }
}