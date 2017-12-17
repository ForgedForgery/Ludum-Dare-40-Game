using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpSystem
{ 

    // TODO: fix airJumps and test if ground jumps work properly

    private bool groundJump = true;
    public bool OnGround { get; set; }

    private int airJumps;
    private int maxAirJumps;
    private float cooldown = 0f;
    private float maxCD = 2f;

    private int jumpsUsed = 0; // just keeps track, otherwise useless

    private bool ready = true;
    public bool Ready { get { return ready; } }

    public JumpSystem(UnitSettings settings)
    {
        maxAirJumps = settings.MaxAirJumps;
        airJumps = maxAirJumps;
    }

    public void tick()
    {
        tickCooldown();

        if (OnGround)
            groundJump = true;

        ready = airJumps > 0 || groundJump ? true : false;
        Debug.Log(ready + " " + OnGround);
    }

    private void tickCooldown()
    {
        if (cooldown > 0f)
        {
            cooldown -= Time.deltaTime;
        }

        // can be cleaner
        if (cooldown <= 0f && airJumps < maxAirJumps)
        {
            airJumps++;
            cooldown = airJumps == maxAirJumps ? 0f : maxCD;
        }
    }

    public void doLogicWhenJumped()
    {
        if (OnGround)
        {
            groundJump = false;
        }
        else if (airJumps > 0)
        {
            jumpsUsed++;
            airJumps--;
            cooldown = cooldown > 0f ? cooldown : maxCD;
        }
    }
}
