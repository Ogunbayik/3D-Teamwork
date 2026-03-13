using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerAirborneState : IState
{
    protected PlayerBase _player;
    protected BaseStateMachine _stateMachine;
    public PlayerAirborneState(PlayerBase player) => _player = player;
    public void SetStateMachine(BaseStateMachine stateMachine) => _stateMachine = stateMachine;
    public abstract void EnterState();
    public abstract void ExitState();
    public virtual void Tick()
    {
        var moveInput = _player.GetMoveInput();
        var inputDirection = new Vector3(moveInput.x, 0f, moveInput.y);
        _player.SetDirection(inputDirection);
    }
}
