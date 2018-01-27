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

    private bool ready = true;
    public bool Ready { get { return ready; } }

    private UnitSettings settings;

    public JumpSystem (UnitSettings _settings)
    {
        settings = _settings;
        airJumpsLeft = settings.MaxAirJumps;
    }

    public void tick ()
    {
        updateSettings ();
        tickCooldown ();
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

    public void checkIfReady (bool isGrounded)
    {
        ready = airJumpsLeft > 0 || isGrounded;
    }

    public void usedJumpInAir ()
    {
        airJumpsLeft--;

        bool cooldownIsTicking = cooldownLeft > 0f;
        cooldownLeft = cooldownIsTicking ? cooldownLeft : maxCooldown;
    }
}
