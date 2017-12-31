using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpSystem
{ 
    public bool Grounded { get; set; }

    private int airJumpsLeft;
    private int maxAirJumps;

    // maybe make a Cooldown class to make the code easier to read
    private float cooldownLeft = 0f;
    private float maxCooldown;

    private bool ready = true;
    public bool Ready { get { return ready; } }

    private UnitSettings settings;

    private int jumpsUsed = 0; // just keeps track, otherwise useless

    public JumpSystem (UnitSettings _settings)
    {
        settings = _settings;
        airJumpsLeft = settings.MaxAirJumps;
    }

    public void tick ()
    {
        updateSettings();
        tickCooldown ();

        ready = airJumpsLeft > 0 || Grounded;
    }

    private void updateSettings()
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

    public void usedJump ()
    {
        jumpsUsed++;

        if (!Grounded)
        {
            airJumpsLeft--;

            bool cooldownIsTicking = cooldownLeft > 0f;
            cooldownLeft = cooldownIsTicking ? cooldownLeft : maxCooldown;
        }
    }
}
