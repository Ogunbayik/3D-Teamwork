using UnityEngine;

[CreateAssetMenu(fileName = "New Player Data", menuName = "ScriptableObject/Player Data")]
public class PlayerData : ScriptableObject
{
    [Header("Player Identity")]
    [SerializeField] private string _name;
    [SerializeField] private Color _color;
    [Header("Movement Settings")]
    [SerializeField] private float _walkSpeed;
    [SerializeField] private float _sprintSpeed;
    [SerializeField] private float _rotationSpeed;
    [Header("Jump Settings")]
    [SerializeField] private float _jumpHeight;
    [Header("Gravity Settings")]
    [SerializeField] private float _gravityMultiplier;
    [SerializeField] private float _groundedGravity;
    [SerializeField] private float _jumpCoefficient;

    public string Name => _name;
    public Color Color => _color;
    public float WalkSpeed => _walkSpeed;
    public float SprintSpeed => _sprintSpeed;
    public float RotationSpeed => _rotationSpeed;
    public float JumpHeight => _jumpHeight;
    public float GravityMultiplier => _gravityMultiplier;
    public float GroundedGravity => _groundedGravity;
    public float JumpCoefficient => _jumpCoefficient;
}
