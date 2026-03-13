using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAirborneState : IState
{
    private PlayerBase _player;
    private BaseStateMachine _stateMachine;

    public PlayerAirborneState(PlayerBase player) => _player = player;
    public void SetStateMachine(BaseStateMachine stateMachine) => _stateMachine = stateMachine;
    public void EnterState()
    {
        _player.AnimationController.PlayAnimation(GameConstant.PlayerAnimation.JUMP_HASH, GameConstant.AnimationSettings.QUICK_TRANSITION);
        _player.HandleJump();
        _player.SetSprintStatus(false);
    }
    public void ExitState()
    {

    }
    public void Tick()
    {
        _player.ApplyGravity();

        var moveInput = _player.GetMoveInput();
        var inputDirection = new Vector3(moveInput.x, 0f, moveInput.y);

        _player.Move(inputDirection);

        if (_player.IsGrounded())
        {
            _player.SetJumpStatus(false);

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
}
