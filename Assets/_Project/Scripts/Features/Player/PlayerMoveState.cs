using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerGroundedState
{
    public PlayerMoveState(PlayerBase player) : base(player) { }

    public override void EnterState()
    {
        base.EnterState();

        Debug.Log("Player is Moving");
    }
    public override void ExitState()
    {
        base.ExitState();
    }
    public override void Tick()
    {
        base.Tick();

        _player.HandleMovement();
    }
}
