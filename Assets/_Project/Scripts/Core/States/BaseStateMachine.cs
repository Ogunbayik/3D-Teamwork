using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public abstract class BaseStateMachine : IInitializable, ITickable
{
    protected List<IState> _states;

    protected IState _currentState;
    public BaseStateMachine(List<IState> states) => _states = states;
    public virtual void Initialize()
    {
        foreach (var state in _states)
            state.SetStateMachine(this);
    }
    public void Tick() => _currentState.Tick();
    public void SwitchState<T>() where T : IState
    {
        if (_currentState is T) return;

        _currentState?.ExitState();
        _currentState = _states.OfType<T>().FirstOrDefault();
        _currentState?.EnterState();
    }

}