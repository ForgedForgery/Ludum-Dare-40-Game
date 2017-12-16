using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpSystem
{

    // Could split the jumping:
    //    - add one normal jump that gets consumed and resets only when you are on the ground
    //    - add multi jumps that or "air" jumps that get consumed while in the air and have CD


    [SerializeField]
    private int maxJumps = 2;
    [SerializeField]
    private float maxCD = 2f;

    private int jumpCharges;
    private float cooldown = 0f;

    private int jumpsUsed = 0; // just keeps track, otherwise useless

    private bool ready = true;
    public bool Ready { get { return ready; } }

    public JumpSystem()
    {
        jumpCharges = maxJumps;
    }

    public void tick()
    {
        tickCooldown();
        ready = jumpCharges > 0 ? true : false;
    }

    private void tickCooldown()
    {
        if (cooldown > 0f)
        {
            cooldown -= Time.deltaTime;
        }

        // can be cleaner
        if (cooldown <= 0f && jumpCharges < maxJumps)
        {
            jumpCharges++;
            cooldown = jumpCharges == maxJumps ? 0f : maxCD;
        }

        Debug.Log(jumpCharges);
    }

    public void doLogicWhenJumped()
    {
        if (jumpCharges > 0)
        {
            jumpsUsed++;
            jumpCharges--;
            cooldown = cooldown > 0f ? cooldown : maxCD;
        }
    }
}
