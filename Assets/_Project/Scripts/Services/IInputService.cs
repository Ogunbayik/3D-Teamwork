using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInputService 
{
    public event Action<Vector2> OnMoveChanged;
    public event Action OnJumpPerformed;
    public event Action<bool> OnSprintPerformed;

    Vector2 MoveInput();
    void Disable();
}
