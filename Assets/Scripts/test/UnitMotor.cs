using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMotor
{
    private readonly IUnitInput input;
    private readonly JumpSystem jumpSystem;
    private readonly Rigidbody rb;
    private readonly UnitSettings settings;

    private bool jumping = false;

    public UnitMotor(IUnitInput input, JumpSystem jumpSystem, Rigidbody rb, UnitSettings settings)
    {
        this.input = input;
        this.jumpSystem = jumpSystem;
        this.rb = rb;
        this.settings = settings;
    }
    
    public void tick()
    {
        checkIfOnGround();
        checkIfJumped();
    }

    // needs to be different
    // should check for collission with ground
    private void checkIfOnGround()
    {
        if (rb.transform.position.y <= 0.5f)
            jumpSystem.OnGround = true;
        else
            jumpSystem.OnGround = false;
    }

    private void checkIfJumped()
    {
        if (input.Jump)
        {
            jumping = true;
        }
    }

    public void tickFixed()
    {
        performMove();
        performRotation();
        if (jumping && jumpSystem.Ready)
            performJump();
    }

    private void performMove()
    {
        Vector3 sideVector = rb.transform.right * input.SideMove;
        Vector3 forwardVector = rb.transform.forward * input.ForwardMove;
        Vector3 destination = (sideVector + forwardVector).normalized * settings.MovementSpeed;
        if (destination != Vector3.zero)
        {
            rb.MovePosition(rb.position + destination * Time.fixedDeltaTime);
        }
    }

    private void performRotation()
    {
        Vector3 rotation = new Vector3(0f, input.SideRotation, 0f) * settings.MovementSpeed;
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));
    }

    private void performJump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(rb.transform.up * settings.JumpForce, ForceMode.Impulse);
        jumping = false;
        jumpSystem.usedJump();
    }
}