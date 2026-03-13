using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPassiveState : PlayerGroundedState
{
    public PlayerPassiveState(PlayerBase player) : base(player) { }

    public override void EnterState()
    {
        //TODO Player için dinlenme animasyonu eklenecek.
        base.EnterState();
        Debug.Log("Passive");
    }
    public override void ExitState()
    {
        base.ExitState();
    }
    public override void Tick()
    {

    }
}
