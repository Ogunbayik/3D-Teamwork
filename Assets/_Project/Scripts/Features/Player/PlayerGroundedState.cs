using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerGroundedState : PlayerBaseState
{
    public PlayerGroundedState(PlayerBase player) : base(player) { }

    public override void EnterState() => base.EnterState();
    public override void ExitState() => base.ExitState();
    public override void Tick()
    {
        if (_player.IsMoving)
            _stateMachine.SwitchState<PlayerMoveState>();
        else
            _stateMachine.SwitchState<PlayerIdleState>();
    }
    
}
