using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MEC;

public abstract class BattleState : State
{
    protected BattleSystem battleSystem;

    public BattleState(BattleSystem battleSystem)
    {
        this.battleSystem = battleSystem;
    }
}
