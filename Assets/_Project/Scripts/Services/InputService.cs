using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputService : IInputService, IDisposable
{
    private readonly PlayerControls _controls;

    public event Action<Vector2> OnMoveChanged;
    public event Action OnJumpPerformed;
    public event Action<bool> OnSprintPerformed;
    public InputService()
    {
        _controls = new PlayerControls();

        _controls.Player.Move.performed += ctx => OnMoveChanged?.Invoke(ctx.ReadValue<Vector2>());
        _controls.Player.Move.canceled += ctx => OnMoveChanged?.Invoke(Vector2.zero);

        _controls.Player.Jump.performed += _ => OnJumpPerformed?.Invoke();

        _controls.Player.Sprint.started += _ => OnSprintPerformed?.Invoke(true);
        _controls.Player.Sprint.canceled += _ => OnSprintPerformed?.Invoke(false);

        _controls.Enable();
    }
    public void Disable() => _controls.Disable();
    public void Dispose() => _controls.Dispose();
    public Vector2 MoveInput() => _controls.Player.Move.ReadValue<Vector2>();

}
