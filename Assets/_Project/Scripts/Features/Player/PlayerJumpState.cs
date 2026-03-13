using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerAirborneState
{
    public PlayerJumpState(PlayerBase player) : base(player) { }

    public override void EnterState()
    {
        _player.HandleJump();
        _player.AnimationController.PlayAnimation(GameConstant.PlayerAnimation.JUMP_HASH, GameConstant.AnimationSettings.QUICK_TRANSITION);
    }

    public override void ExitState()
    {

    }

    public override void Tick()
    {
        base.Tick();

        if (_player.VelocityY <= 0)
            _stateMachine.SwitchState<PlayerFallState>();
    }
}
