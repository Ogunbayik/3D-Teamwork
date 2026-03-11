using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
    void SetStateMachine(BaseStateMachine stateMachine);
    void EnterState();
    void ExitState();
    void Tick();
}
