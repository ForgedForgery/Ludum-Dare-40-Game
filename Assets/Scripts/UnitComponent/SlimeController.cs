using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeController : IUnitInput
{
    public float ForwardMove { get; private set; }
    public float SideMove { get; private set; }
    public float SideRotation { get; private set; }
    public bool Jump { get; private set; }

    public void readInput()
    {

    }
}
