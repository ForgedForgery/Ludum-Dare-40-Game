using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpSystem
{ 
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
    }

    private void tickCooldown()
    {
        if (cooldown > 0f)
        {
            cooldown -= Time.deltaTime;
        }
        else if (airJumps < maxAirJumps)
        {
            airJumps++;
            cooldown = airJumps == maxAirJumps ? 0f : maxCD;
        }
    }

    public void usedJump()
    {
        if (OnGround)
        {
            groundJump = false;
        }
        else
        {
            jumpsUsed++;
            airJumps--;
            cooldown = cooldown > 0f ? cooldown : maxCD;
        }
    }
}
