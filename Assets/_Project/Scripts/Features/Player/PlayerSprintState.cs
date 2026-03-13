using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSprintState : PlayerGroundedState
{
    public PlayerSprintState(PlayerBase player) : base(player) { }

    public override void EnterState()
    {
        base.EnterState();
        _player.SetCurrentSpeed(_player.Data.SprintSpeed);
        _player.AnimationController.PlayAnimation(GameConstant.PlayerAnimation.SPRINT_HASH, GameConstant.AnimationSettings.QUICK_TRANSITION);
    }
    public override void ExitState()
    {
        base.ExitState();
    }
    public override void Tick()
    {
        base.Tick();

        var moveInput = _player.GetMoveInput();
        var inputDirection = new Vector3(moveInput.x, 0f, moveInput.y);

        _player.Move(inputDirection);
    }
}
