using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [field: SerializeField] public Transform RightHand { get; private set; }
    [field: SerializeField] public Transform LeftHand { get; private set; }
    
    public PlayerAnimationController PlayerAnimController { get; private set; }
    public PlayerController PlayerController { get; private set; }

    private void Awake()
    {
        InitOnCreate();
    }

    public void InitOnCreate()
    {
        PlayerAnimController = GetComponent<PlayerAnimationController>();
        PlayerController = GetComponent<PlayerController>();
        
        PlayerAnimController.InitOnCreate(this);
        PlayerController.InitOnCreate(this);
    }

    private void Start()
    {
        InitOnActivate();
    }

    public void InitOnActivate()
    {
        PlayerAnimController.InitOnActivate();
    }
}
