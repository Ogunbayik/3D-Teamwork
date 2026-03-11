using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputService : IInputService, IDisposable
{
    private readonly PlayerControls _controls;

    public event Action<Vector2> OnMoveChanged;
    public InputService()
    {
        _controls = new PlayerControls();

        _controls.Player.Move.performed += ctx => OnMoveChanged?.Invoke(ctx.ReadValue<Vector2>());
        _controls.Player.Move.canceled += ctx => OnMoveChanged?.Invoke(Vector2.zero);

        _controls.Enable();
    }
    public void Disable() => _controls.Disable();
    public void Dispose() => _controls.Dispose();
    public Vector2 MoveInput() => _controls.Player.Move.ReadValue<Vector2>();
    public bool IsPressedJump()
    {
        return true;
    }

}
