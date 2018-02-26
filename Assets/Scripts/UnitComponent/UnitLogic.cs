using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitLogic
{
    public float ForwardMove { get { return input.ForwardMove; } }
    public float SideMove { get { return input.SideMove; } }
    public float SideRotation { get { return input.SideRotation; } }
    public float HorizontalCamRotation { get { return camInput.HorizontalCamRotation; } }

    private bool jumping = false;
    public bool Jumping { get { return jumping; } }

    private bool grounded = true;
    public bool Grounded { get { return grounded; } }

    private UnitSettings settings;

    private IUnitInput input;
    private ICamInput camInput;

    private JumpSystem jumpSystem;

    public UnitLogic(UnitSettings _settings = null)
    {
        this.settings = _settings;

        if (settings.IsPlayer)
        {
            input = new PlayerController() as IUnitInput;
            camInput = new PlayerController() as ICamInput;
        }
        else
        {
            input = new SlimeController() as IUnitInput;
        }
        jumpSystem = new JumpSystem(settings);
    }

    public void Tick()
    {
        jumpSystem.Tick();
        input.readInput();

        checkIfJumping();
    }

    private void checkIfJumping()
    {
        if (input.Jump && jumpSystem.ready)
            jumping = true;
    }

    public void OnLand()
    {
        grounded = true;
        jumpSystem.ready = true;
    }

    public void usedJump()
    {
        // probably change to inAir or make an enum for states
        if (!grounded)
            jumpSystem.usedJumpInAir();
        jumping = false;
    }
}
