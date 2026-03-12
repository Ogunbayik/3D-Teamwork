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

    private bool _isMoving;
    private bool _isJumping;

    private float _velocityY;
    public bool IsMoving => _isMoving;
    public bool IsJumping => _isJumping;
    public float VelocityY => _velocityY;
    public AnimationController AnimationController => _animationController;

    [Inject]
    public void Construct(IInputService input, CharacterController characterController, AnimationController animationController)
    {
        _input = input;
        _characterController = characterController;
        _animationController = animationController;
    }
    private void OnEnable()
    {
        _input.OnMoveChanged += SetMoveStatus;
        _input.OnJumpPerformed += Input_OnJumpPerformed;
    }
    private void OnDisable()
    {
        _input.OnMoveChanged -= SetMoveStatus;
        _input.OnJumpPerformed -= Input_OnJumpPerformed;
    }
    public void SetMoveStatus(Vector2 moveVector) => _isMoving = moveVector != Vector2.zero;
    public void ApplyGravity()
    {
        if (IsGrounded() && _velocityY <= 0)
            _velocityY = _data.GroundedGravity;
        else
            _velocityY += Physics.gravity.y * _data.GravityMultiplier * Time.deltaTime;
    }
    public bool IsGrounded() => Physics.CheckSphere(_groundCheck.transform.position, _checkRadius, _checkLayer);
    public void HandleJump() => _velocityY = Mathf.Sqrt(_data.JumpHeight * _data.JumpCoefficient * Physics.gravity.y);
    public void Move(Vector3 movementDirection)
    {
        Vector3 finalMovement = movementDirection * _data.MovementSpeed;
        finalMovement.y = _velocityY;

        _characterController.Move(finalMovement * Time.deltaTime);

        HandleRotation();
    }
    private void HandleRotation()
    {
        if(_isMoving)
        {
            var moveInput = GetMoveInput();
            var targetDirection = new Vector3(moveInput.x, 0f, moveInput.y);
            var targetRotation = Quaternion.LookRotation(targetDirection);
            transform.rotation = Quaternion.Slerp(_bodyVisual.transform.rotation, targetRotation, _data.RotationSpeed * Time.deltaTime);
        }
    }
    public Vector2 GetMoveInput() => _input.MoveInput();
    private void Input_OnJumpPerformed() => SetJumpStatus(true);
    public void SetJumpStatus(bool isActive) => _isJumping = isActive;
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;

        Gizmos.DrawSphere(_groundCheck.position, _checkRadius);
    }


}
