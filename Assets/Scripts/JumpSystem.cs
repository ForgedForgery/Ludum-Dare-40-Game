using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpSystem : MonoBehaviour
{
    [SerializeField]
    private int maxJumpAmount = 2;
    [SerializeField]
    private float maxJumpCD = 2f;

    private int jumpsUsed = 0;
    private int jumpsAllowed;
    private float jumpCD = 0f;
    private bool onGround = true;

    public delegate void JumpEvents();
    public static JumpEvents onJump;

    private void Start()
    {
        jumpsAllowed = maxJumpAmount;
        PlayerMotor.onPlayerLand += resetOneJumpOnLanding;
    }

    private void Update()
    {
        tickCooldown();
        doJumpWithSpace();
    }

    private void tickCooldown()
    {
        if (jumpCD > 0f)
        {
            jumpCD -= Time.deltaTime;
        }

        if (jumpCD <= 0f && jumpsAllowed < maxJumpAmount)
        {
            jumpsAllowed++;
            jumpCD = jumpsAllowed == maxJumpAmount ? 0f : maxJumpCD;
        }

        Debug.Log(jumpsAllowed);
    }

    private void doJumpWithSpace()
    {
        if (Input.GetButtonDown("Jump"))
        {
            onPlayerPressJump();
        }
    }

    public void onPlayerPressJump()
    {
        if(jumpsAllowed > 0)
        {
            onGround = false;
            jumpsUsed++;
            jumpsAllowed--;
            jumpCD = jumpCD > 0f ? jumpCD : maxJumpCD;
            onJump();
        }
    }

    private void resetOneJumpOnLanding() // currently useless
    {
        if(!onGround)
        {
            onGround = true;
        }
    }

}
