using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : BaseStateMachine
{
    public PlayerStateMachine(List<IState> states) : base(states) { }

    public override void Initialize()
    {
        base.Initialize();

        SwitchState<PlayerIdleState>();
    }
}
