using UnityEngine;

[CreateAssetMenu(menuName = "Unit/Settings", fileName = "UnitData")]
public class UnitSettings : ScriptableObject
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
    private bool isPlayer = false;

    public float LookSensitivity { get { return lookSensitivity; } }
    public float MovementSpeed { get { return movementSpeed; } }
    public float JumpForce { get { return jumpForce; } }
    public int MaxAirJumps { get { return maxAirJumps; } }
    public bool IsPlayer { get { return isPlayer; } }
}
