using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : IUnitInput, ICamInput
{
    public float ForwardMove { get; private set; }
    public float SideMove { get; private set; }
    public float SideRotation { get; private set; }
    public bool Jump { get; private set; }

    public float yCamRotation { get; private set; }

    public void readInput()
    {
        ForwardMove = Input.GetAxisRaw("Vertical");
        SideMove = Input.GetAxisRaw("Horizontal");

        SideRotation = Input.GetAxisRaw("Mouse X");
        yCamRotation = Input.GetAxisRaw("Mouse Y");

        Jump = Input.GetButtonDown("Jump");
    }
}