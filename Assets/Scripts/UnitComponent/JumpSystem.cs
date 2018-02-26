using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpSystem
{ 

    private int airJumpsLeft;
    private int maxAirJumps;

    // TODO:
    // maybe make a Cooldown class to make the code easier to read
    private float cooldownLeft = 0f;
    private float maxCooldown;

    public bool ready = true;

    private IJumpSettings settings;

    public JumpSystem (IJumpSettings _settings)
    {
        settings = _settings;
        airJumpsLeft = settings.MaxAirJumps;
    }

    public void Tick ()
    {
        updateSettings ();
        tickCooldown ();
        checkIfReady ();
    }

    private void updateSettings ()
    {
        maxAirJumps = settings.MaxAirJumps;
        maxCooldown = settings.MaxCD;
    }

    private void tickCooldown ()
    {
        bool cooldownIsTicking = cooldownLeft > 0f;
        if (cooldownIsTicking)
        {
            cooldownLeft -= Time.deltaTime;
        }
        else if (airJumpsLeft < maxAirJumps)
        {
            airJumpsLeft++;

            cooldownLeft = maxCooldown;
            if (airJumpsLeft == maxAirJumps)
                cooldownLeft = 0f;
        }
    }

    private void checkIfReady ()
    {
        ready = airJumpsLeft > 0;
    }

    public void usedJumpInAir ()
    {
        airJumpsLeft--;

        bool cooldownIsTicking = cooldownLeft > 0f;
        cooldownLeft = cooldownIsTicking ? cooldownLeft : maxCooldown;
    }
}
