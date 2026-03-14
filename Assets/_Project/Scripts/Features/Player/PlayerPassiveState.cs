using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPassiveState : PlayerBaseState
{
    public PlayerPassiveState(PlayerBase player) : base(player) { }

    public override void EnterState()
    {
        //TODO Player için dinlenme animasyonu eklenecek.
        _player.AnimationController.PlayAnimation(GameConstant.PlayerAnimation.PASSIVE_HASH, GameConstant.AnimationSettings.SMOOTH_TRANSITION);
    }
    public override void ExitState()
    {

    }
    public override void Tick()
    {

    }
}
