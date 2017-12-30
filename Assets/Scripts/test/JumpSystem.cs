using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpSystem
{ 
    public bool Grounded { get; set; }

    private int airJumpsAvailable;
    private int maxAirJumps;

    private float cooldown = 0f;
    private float maxCD;

    private bool ready = true;
    public bool Ready { get { return ready; } }

    private UnitSettings settings;

    private int jumpsUsed = 0; // just keeps track, otherwise useless

    public JumpSystem (UnitSettings _settings)
    {
        settings = _settings;
        airJumpsAvailable = settings.MaxAirJumps;
    }

    public void tick ()
    {
        updateSettings();
        tickCooldown ();

        ready = airJumpsAvailable > 0 || Grounded;
    }

    private void updateSettings()
    {
        maxAirJumps = settings.MaxAirJumps;
        maxCD = settings.MaxCD;
    }

    private void tickCooldown ()
    {
        if (cooldown > 0f)
        {
            cooldown -= Time.deltaTime;
        }
        else if (airJumpsAvailable < maxAirJumps)
        {
            airJumpsAvailable++;

            if (airJumpsAvailable == maxAirJumps)
                cooldown = 0f;
            else
                cooldown = maxCD;
        }
    }

    public void usedJump ()
    {
        jumpsUsed++;

        if (!Grounded)
        {
            airJumpsAvailable--;
            cooldown = cooldown > 0f ? cooldown : maxCD;
        }
    }
}
