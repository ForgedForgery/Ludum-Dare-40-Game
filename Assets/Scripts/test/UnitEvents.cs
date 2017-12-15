using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitEvents
{
    private IUnitInput input;
    private Transform transform;

    public delegate void UnitEventMethods();
    public UnitEventMethods onPlayerLand;
    public UnitEventMethods onPlayerJump;

    public UnitEvents(IUnitInput input, Transform unitTransform)
    {
        this.input = input;
        this.transform = unitTransform;
    }

    public void tick()
    {
        checkForPlayerLand();
        checkForPlayerJumping();
    }

    private void checkForPlayerJumping()
    {
        if (input.Jumping)
        {
            onPlayerJump();
        }
    }

    private void checkForPlayerLand()
    {
        if (transform.position.y <= 0.5f)
        {
            //onPlayerLand();
        }
    }
}