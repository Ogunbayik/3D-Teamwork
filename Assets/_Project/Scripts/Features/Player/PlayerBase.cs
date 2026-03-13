using UnityEngine;
using Zenject;

public class PlayerBase : MonoBehaviour
{
    [Header("Data References")]
    [SerializeField] private PlayerData _data;
    [SerializeField] private Transform _bodyVisual;
    [Header("Check Settings")]
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _checkRadius;
    [SerializeField] private LayerMask _checkLayer;

    private IInputService _input;

    private AnimationController _animationController;
    private CharacterController _characterController;

    private bool _isJumping;
    private bool _isSprint;

    private float _velocityY;
    public bool IsJumping => _isJumping;
    public bool IsSprint => _isSprint;
    public float VelocityY => _velocityY;
    public AnimationController AnimationController => _animationController;
    public IInputService Input => _input;

    private float _currentSpeed;

    public PlayerData Data => _data;

    [Inject]
    public void Construct(IInputService input, CharacterController characterController, AnimationController animationController)
    {
        _input = input;
        _characterController = characterController;
        _animationController = animationController;
    }
    public void SetJumpStatus(bool isActive) => _isJumping = isActive;
    public void SetSprintStatus(bool isPressed) => _isSprint = isPressed;
    public void ApplyGravity()
    {
        if (IsGrounded() && _velocityY <= 0)
            _velocityY = _data.GroundedGravity;
        else
            _velocityY += Physics.gravity.y * _data.GravityMultiplier * Time.deltaTime;
    }
    public bool IsMoving() => GetMoveInput().sqrMagnitude > 0.15f;
    public bool IsGrounded() => Physics.CheckSphere(_groundCheck.transform.position, _checkRadius, _checkLayer);
    public void HandleJump() => _velocityY = Mathf.Sqrt(_data.JumpHeight * _data.JumpCoefficient * Physics.gravity.y);
    public void Move(Vector3 movementDirection)
    {
        Vector3 finalMovement = movementDirection * _currentSpeed;
        finalMovement.y = _velocityY;

        _characterController.Move(finalMovement * Time.deltaTime);

        HandleRotation();
    }
    private void HandleRotation()
    {
        var moveInput = GetMoveInput();
        var inputDirection = new Vector3(moveInput.x, 0f, moveInput.y);
        if (inputDirection.sqrMagnitude < 0.01f) return;

        var targetRotation = Quaternion.LookRotation(inputDirection);
        _bodyVisual.transform.rotation = Quaternion.Slerp(_bodyVisual.transform.rotation, targetRotation, _data.RotationSpeed * Time.deltaTime);
    }
    public void SetCurrentSpeed(float speed) => _currentSpeed = speed;
    public Vector2 GetMoveInput() => _input.MoveInput();
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;

        Gizmos.DrawSphere(_groundCheck.position, _checkRadius);
    }


}
