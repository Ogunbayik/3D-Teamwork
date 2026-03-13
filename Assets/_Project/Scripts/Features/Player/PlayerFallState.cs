using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallState : PlayerAirborneState
{
    public PlayerFallState(PlayerBase player) : base(player) { }

    public override void EnterState()
    {
        Debug.Log("Play Fall animation");
    }

    public override void ExitState()
    {

    }
    public override void Tick()
    {
        base.Tick();

        if (_player.IsGrounded())
            HandleLanding();
    }
    private void HandleLanding()
    {
        _player.SetJumpStatus(false);

        if (_player.IsMoving())
            _stateMachine.SwitchState<PlayerWalkState>();
        else
            _stateMachine.SwitchState<PlayerIdleState>();
    }
}
