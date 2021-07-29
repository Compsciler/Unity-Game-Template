using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MEC;

public class StartState : BattleState
{
    internal static bool isGameJustOver = false;

    public StartState(BattleSystem battleSystem) : base(battleSystem)
    {

    }

    public override IEnumerator<float> OnStateEnter()
    {
        yield return Timing.WaitForOneFrame;
    }

    public override void OnStateUpdate()
    {
        if (isGameJustOver)
        {
            battleSystem.SetState(new GameOverState(battleSystem));
            isGameJustOver = false;
        }
    }
}
