using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerGroundedState
{
    public PlayerIdleState(PlayerBase player) : base(player) { }
    public override void EnterState()
    {
        base.EnterState();
        Debug.Log("Player is Idle mode on");
    }
    public override void ExitState()
    {
        base.ExitState();
    }
    public override void Tick()
    {
        base.Tick();

        
    }
}
