using System;
using UnityEngine;

public class StateBehaviour : StateMachineBehaviour
{
    public Action StateEnterEvent;
    public Action StateEndEvent;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        StateEnterEvent?.Invoke();
    }
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        StateEndEvent?.Invoke();
    }

    public int GetHash()
    {
        return this.GetHashCode();
    }
    public void ResetEvent()
    {
        StateEnterEvent = null;
        StateEndEvent = null;
    }
}