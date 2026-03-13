using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerGroundedState : PlayerBaseState
{
    public PlayerGroundedState(PlayerBase player) : base(player) { }

    public override void EnterState()
    {
        base.EnterState();

        _player.Input.OnJumpPerformed += Input_OnJumpPerformed;
        _player.Input.OnSprintPerformed += Input_OnSprintPerformed;
    }
    public override void ExitState()
    {
        base.ExitState();
        _player.Input.OnJumpPerformed -= Input_OnJumpPerformed;
        _player.Input.OnSprintPerformed -= Input_OnSprintPerformed;
    }
    private void Input_OnJumpPerformed() => _player.SetJumpStatus(true);
    private void Input_OnSprintPerformed(bool isSprint) => _player.SetSprintStatus(isSprint);
    public override void Tick()
    {
        if (_player.IsJumping)
        {
            _stateMachine.SwitchState<PlayerAirborneState>();
            return;
        }


        if (_player.IsMoving())
        {
            if (_player.IsSprint)
                _stateMachine.SwitchState<PlayerSprintState>();
            else
                _stateMachine.SwitchState<PlayerMoveState>();
        }
        else
            _stateMachine.SwitchState<PlayerIdleState>();
    }
    
}
