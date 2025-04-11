using System;

[Flags]
public enum PlayerState
{
    Idle,
    Move,
    Attack,
    Defense,
    Hit,
    Dead
}