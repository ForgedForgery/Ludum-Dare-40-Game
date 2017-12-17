using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamMotor
{
    private readonly ICamInput input;
    private readonly Camera cam;
    private readonly Transform player;
    private readonly UnitSettings settings;

    public PlayerCamMotor(ICamInput input, Transform player, Camera cam, UnitSettings settings)
    {
        this.input = input;
        this.player = player;
        this.cam = cam;
        this.settings = settings;
    }

    public void tickFixed()
    {
        performRotation();
    }

    private void performRotation()
    {
        float rotationAngle = -input.yCamRotation * settings.LookSensitivity;
        cam.transform.RotateAround(player.position, player.right, rotationAngle);
    }
}
