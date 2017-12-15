using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerMotor
{
    private readonly IInput input;
    private readonly Rigidbody rb;
    private readonly MovementSettings settings;

    public TestPlayerMotor(ITestInput input, Rigidbody rb, MovementSettings settings)
    {
        this.input = input;
        this.rb = rb;
    }
    
    tick()
    {
        performMove();
        performRotation();
    }
    
    private void performMove()
    {
        if (input.Velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + input.Velocity * Time.fixedDeltaTime);
        }
    }

    private void performRotation()
    {
        rb.MoveRotation(rb.rotation * Quaternion.Euler(input.Rotation));
        cam.transform.RotateAround(rb.transform.position, transform.right, camRotation.x); // cam rotation needs to be seperate
    }
}

[RequireComponent(typeof(Camera), typeof(Rigidbody))]
public class TestPlayerMotor2 : MonoBehaviour
{
    private Rigidbody rb;
    private Camera cam;
    
    private Vector3 camRotation = Vector3.zero;
    private Vector3 velocity = Vector3.zero;
    private Vector3 rotation = Vector3.zero;
    // TODO: add properties of the above

    private void Start()
    {
        cam = GetComponent<Camera>();
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
        cam.transform.RotateAround(this.transform.position, transform.right, camRotation.x); 
    }
      
    public void thrustUp()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(transform.up * thrustForce, ForceMode.Impulse);
    }
}
