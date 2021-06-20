using UnityEngine;
using MEC;

public abstract class StateMachine : MonoBehaviour
{
    protected State state;

    public void SetState(State state)
    {
        Timing.RunCoroutine(state.OnStateExit());
        this.state = state;
        Timing.RunCoroutine(state.OnStateEnter());
    }
}