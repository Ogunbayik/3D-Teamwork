using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPassiveState : PlayerBaseState
{
    public PlayerPassiveState(PlayerBase player) : base(player) { }

    public override void EnterState()
    {
        //TODO Player için dinlenme animasyonu eklenecek.
        Debug.Log("Passive");
    }
    public override void ExitState()
    {

    }
    public override void Tick()
    {

    }
}
