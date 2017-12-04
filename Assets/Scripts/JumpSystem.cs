using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpSystem : MonoBehaviour
{
    [SerializeField]
    const int maxJumpAmount = 2;
    [SerializeField]
    const float maxJumpCD = 2f;

    private int jumpsUsed = 0;
    private int jumpsAllowed;
    private float jumpCD = 0f;
    private bool onGround = true;

    public delegate void JumpEvents();
    public static JumpEvents onJump;

    private void Start()
    {
        jumpsAllowed = maxJumpAmount;
        PlayerController.onPlayerPressJump += registerJump;
        PlayerMotor.onPlayerLand += resetOneJumpOnLanding;
    }

    private void Update()
    {
        if(jumpCD > 0f)
        {
            jumpCD -= Time.deltaTime;
        }

        if(jumpCD <= 0f && jumpsAllowed <= maxJumpAmount)
        {
            jumpsAllowed++;
            jumpCD = maxJumpCD;
           
        }


        Debug.Log(jumpsAllowed);
    }

    public void registerJump()
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

    private void resetOneJumpOnLanding()
    {
        if(!onGround)
        {
            onGround = true;
            jumpsAllowed++;
            
        }
    }

}
