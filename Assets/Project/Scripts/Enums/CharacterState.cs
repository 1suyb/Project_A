using System;

[Flags]
public enum CharacterState
{
    Idle,
    Move,
    Attack,
    Defense,
    Hit,
    Dead
}