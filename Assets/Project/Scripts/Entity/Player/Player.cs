using System;
using UnityEngine;

public class Player : Entity
{
    [field: SerializeField] public Transform RightHand { get; private set; }
    [field: SerializeField] public Transform LeftHand { get; private set; }
    
    public PlayerAnimationController PlayerAnimController { get; private set; }
    public PlayerController PlayerController { get; private set; }
    public PlayerStatus PlayerStatus { get; private set; }

    private void Awake()
    {
        InitOnCreate();
    }

    public void InitOnCreate()
    {
        PlayerAnimController = GetComponent<PlayerAnimationController>();
        PlayerController = GetComponent<PlayerController>();
        PlayerStatus = GetComponent<PlayerStatus>();
        
        PlayerAnimController.InitOnCreate(this);
        PlayerController.InitOnCreate(this);
        PlayerStatus.InitOnCreate(this);
    }

    private void Start()
    {
        InitOnActivate();
    }

    public void InitOnActivate()
    {
        PlayerAnimController.InitOnActivate();
        PlayerStatus.InitOnActivate();
    }
}