using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MEC;
using UnityEngine.UI;

// For button click methods, GameObject/component references for states, and battle Start() and Update()
public class BattleSystem : StateMachine<BattleState>
{
    [SerializeField] internal GameOverMenu gameOverMenu;

    void Start()
    {
        SetState(new StartState(this));
    }

    protected override void Update()
    {
        base.Update();
    }
}
