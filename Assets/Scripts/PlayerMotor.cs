using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour
{
    [SerializeField]
    private Camera cam;

    [SerializeField]
    private float thrustForce = 3f;

    private Vector3 velocity = Vector3.zero;
    private Vector3 rotation = Vector3.zero;
    private Vector3 camRotation = Vector3.zero;

    private Rigidbody rb;

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
        checkForPlayerLand();
    }

    private void checkForPlayerLand()
    {
        if (transform.position.y <= 0.5f)
        {
            onPlayerLand();
        }
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
        cam.transform.RotateAround(transform.position, transform.right, camRotation.x);
    }

    public void setMovement(Vector3 _velocity)
    {
        velocity = _velocity;
    }

    public void setRotation(Vector3 _rotation)
    {
        rotation = _rotation;
    }

    public void setCamRotation(Vector3 _rotation)
    {
        camRotation = _rotation;
    }

    public void thrustUp()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(transform.up * thrustForce, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        onPlayerLand();
    }
}
