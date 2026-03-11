using UnityEngine;
using Zenject;

public class PlayerBase : MonoBehaviour
{
    private IInputService _input;

    private CharacterController _characterController;

    private bool _isMoving;
    public bool IsMoving => _isMoving;

    [Inject]
    public void Construct(IInputService input,CharacterController characterController)
    {
        _input = input;
        _characterController = characterController;

        _input.OnMoveChanged += SetMoveStatus;
    }
    public void SetMoveStatus(Vector2 moveVector) => _isMoving = moveVector != Vector2.zero;

    public void HandleMovement()
    {
        var moveInput = _input.MoveInput();
        var moveDirection = new Vector3(moveInput.x, 0f, moveInput.y);
        var move = moveDirection * 5f * Time.deltaTime;

        _characterController.Move(move);
    }



}
