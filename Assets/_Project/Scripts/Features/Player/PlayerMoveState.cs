using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerGroundedState
{
    public PlayerMoveState(PlayerBase player) : base(player) { }

    public override void EnterState()
    {
        base.EnterState();
        _player.AnimationController.PlayAnimation(GameConstant.PlayerAnimation.WALK_HASH, GameConstant.AnimationSettings.QUICK_TRANSITION);
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
