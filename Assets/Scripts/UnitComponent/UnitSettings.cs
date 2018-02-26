using UnityEngine;

[CreateAssetMenu(menuName = "Unit/Settings", fileName = "UnitData")]
public class UnitSettings : ScriptableObject, IJumpSettings
{

    [SerializeField]
    private float lookSensitivity = 5f;
    [SerializeField]
    private float movementSpeed = 5f;
    [SerializeField]
    private float jumpForce = 5f;
    [SerializeField]
    private int maxAirJumps = 2;
    [SerializeField]
    private float maxCD = 2f;
    [SerializeField]
    private bool isPlayer = false;

    public float LookSensitivity { get { return lookSensitivity; } }
    public float MovementSpeed { get { return movementSpeed; } }
    public float JumpForce { get { return jumpForce; } }
    public int MaxAirJumps { get { return maxAirJumps; } }
    public float MaxCD { get { return maxCD; } }
    public bool IsPlayer { get { return isPlayer; } }
}

public interface IJumpSettings
{
    float MaxCD { get; }
    int MaxAirJumps { get; }
}