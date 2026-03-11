using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBaseState : IState
{
    protected PlayerBase _player;
    protected BaseStateMachine _stateMachine;
    public PlayerBaseState(PlayerBase player) => _player = player;
    public void SetStateMachine(BaseStateMachine stateMachine) => _stateMachine = stateMachine;
    public virtual void EnterState() { }
    public virtual void ExitState() { }
    public abstract void Tick();
}
