using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour
{
    private Rigidbody rb;
    
    private Vector3 velocity = Vector3.zero;
    private Vector3 rotation = Vector3.zero;
    // TODO: add properties of the above
    
    public delegate void PlayerMotorEvents();
    public static event PlayerMotorEvents onPlayerLand;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        JumpSystem.onJump += thrustUp;
    }
    
    private void FixedUpdate()
    {
        performMove();
        performRotation();
    }
    
    private void performMove()
    {
        if (velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }
    }

    private void performRotation()
    {
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));
    }
    
    // TODO: move the player landing event somewhere else
    private void checkForPlayerLand()
    {
        if (transform.position.y <= 0.5f)
        {
            onPlayerLand();
        }
    }
}
