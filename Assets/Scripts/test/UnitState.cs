using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitState : MonoBehaviour
{
    private readonly Rigidbody rb;
    private readonly IUnitInput input;
    private readonly JumpSystem jumpSystem;

    private bool jumping = false;
    public bool Jumping { get { return jumping; } }

    private bool grounded = true;
    public bool Grounded { get { return grounded; } }

    public UnitState (Rigidbody rb, IUnitInput input, JumpSystem jumpSystem)
    {
        this.rb = rb;
        this.input = input;
        this.jumpSystem = jumpSystem;
    }

    public void tick ()
    {
        checkIfOnGround();
        jumpSystem.checkIfReady(grounded);
        checkIfJumped();
    }

    // TODO:
    // needs to be different
    // should check for collission with ground or something similar
    private void checkIfOnGround()
    {
        grounded = rb.transform.position.y <= 0.51f;
    }

    private void checkIfJumped()
    {
        if (input.Jump && jumpSystem.Ready)
            jumping = true;
    }

    public void usedJump()
    {
        // probably change to inAir or make an enum for states
        if(!grounded)
            jumpSystem.usedJumpInAir();
        jumping = false;
    }
}
