using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Unit : MonoBehaviour
{
    [SerializeField]
    private Camera cam;
    [SerializeField]
    private UnitSettings unitSettings;

    private IUnitInput playerInput;
    private UnitMotor motor;

    private ICamInput playerCamInput;
    private PlayerCamMotor camMotor;

    private JumpSystem jumpSystem;

    // add new attacksystem here

    private void Start()
    {
        playerInput = unitSettings.IsPlayer ? new PlayerController() as IUnitInput: new SlimeController();

        jumpSystem = new JumpSystem();
        motor = new UnitMotor(playerInput, jumpSystem, GetComponent<Rigidbody>(), unitSettings);

        if (cam != null)
        {
            playerCamInput = new PlayerController();
            camMotor = new PlayerCamMotor(playerCamInput, GetComponent<Transform>(), cam, unitSettings);
        }
    }
    
    private void Update()
    {
        playerInput.readInput();
        if (cam != null)
            playerCamInput.readInput();
        jumpSystem.tick();
    }

    private void FixedUpdate()
    {
        motor.tick();
        if (cam != null)
            camMotor.tick();
    }
}
