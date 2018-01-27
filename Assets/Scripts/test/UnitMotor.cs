using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// maybe split the logic of tick and fixedTick?
public class UnitMotor
{
    private readonly IUnitInput input;
    private readonly UnitState state;
    private readonly Rigidbody rb;
    private readonly UnitSettings settings;

    public UnitMotor(IUnitInput input, UnitState state, Rigidbody rb, UnitSettings settings)
    {
        this.input = input;
        this.state = state;
        this.rb = rb;
        this.settings = settings;
    }
    
    public void tick()
    {

    }

    public void tickFixed()
    {
        performMove();
        performRotation();
        if (state.Jumping)
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

        state.usedJump();
    }
}