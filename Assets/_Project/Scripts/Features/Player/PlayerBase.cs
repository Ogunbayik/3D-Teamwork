using Cinemachine;
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
    [Header("Camera Settings")]
    [SerializeField] public CinemachineVirtualCamera _playerCamera;

    private IInputService _input;

    private CameraManager _cameraManager;
    private PlayerStateMachine _stateMachine;
    private AnimationController _animationController;
    private CharacterController _characterController;
    private SkinnedMeshRenderer _meshRenderer;

    private bool _isJumping;
    private bool _isSprint;

    private float _velocityY;
    public bool IsJumping => _isJumping;
    public bool IsSprint => _isSprint;
    public AnimationController AnimationController => _animationController;
    public IInputService Input => _input;
    public PlayerStateMachine StateMachine => _stateMachine;
    public PlayerData Data => _data;

    private Vector3 _movementDirection;
    private float _currentSpeed;

    public float VelocityY => _velocityY;

    [Inject]
    public void Construct(IInputService input, 
        CharacterController characterController, 
        AnimationController animationController, 
        SkinnedMeshRenderer meshRenderer,
        PlayerStateMachine stateMachine,
        CameraManager cameraManager)
    {
        _input = input;
        _characterController = characterController;
        _animationController = animationController;
        _meshRenderer = meshRenderer;
        _stateMachine = stateMachine;
        _cameraManager = cameraManager;
    }
    private void Start() => Initialize();
    private void Initialize()
    {
        _meshRenderer.material.color = _data.Color;
        _cameraManager.RegisterCamera(_playerCamera);
    }
    public void SetSpeed(float speed) => _currentSpeed = speed;
    public void SetDirection(Vector3 direction) => _movementDirection = direction;
    public void SetJumpStatus(bool isActive) => _isJumping = isActive;
    public void SetSprintStatus(bool isPressed) => _isSprint = isPressed;
    private void Update()
    {
        ApplyGravity();

        ApplyFinalMovement();
    }
    private void ApplyFinalMovement()
    {
        Vector3 horizontalMovement = _movementDirection * _currentSpeed;
        Vector3 finalMovement = horizontalMovement;
        finalMovement.y = _velocityY;

        _characterController.Move(finalMovement * Time.deltaTime);

        HandleRotation();
    }
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
    private void HandleRotation()
    {
        var moveInput = GetMoveInput();
        var inputDirection = new Vector3(moveInput.x, 0f, moveInput.y);
        if (inputDirection.sqrMagnitude < 0.01f) return;

        var targetRotation = Quaternion.LookRotation(inputDirection);
        _bodyVisual.transform.rotation = Quaternion.Slerp(_bodyVisual.transform.rotation, targetRotation, _data.RotationSpeed * Time.deltaTime);
    }
    public void DeactivatePlayer()
    {
        _stateMachine.SwitchState<PlayerPassiveState>();
        enabled = false;
    }
    public void ActivatePlayer()
    {
        enabled = true;
        _stateMachine.SwitchState<PlayerIdleState>();
    }
    public Vector2 GetMoveInput() => _input.MoveInput();
    private void OnDrawGizmos()
    {
        Gizmos.color = _data.Color;

        Gizmos.DrawSphere(_groundCheck.position, _checkRadius);
    }


}
