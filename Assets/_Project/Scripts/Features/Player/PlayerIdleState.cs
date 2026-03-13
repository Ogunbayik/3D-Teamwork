using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerGroundedState
{
    public PlayerIdleState(PlayerBase player) : base(player) { }
    public override void EnterState()
    {
        base.EnterState();
        _player.AnimationController.PlayAnimation(GameConstant.PlayerAnimation.IDLE_HASH, 0);
    }
    public override void ExitState()
    {
        base.ExitState();
    }
    public override void Tick()
    {
        base.Tick();
    }
}
