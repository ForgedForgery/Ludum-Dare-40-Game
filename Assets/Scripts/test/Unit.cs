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

    private IUnitInput unitInput;
    private UnitMotor motor;

    private ICamInput camInput;
    private PlayerCamMotor camMotor;

    private JumpSystem jumpSystem;

    private UnitState state;

    // TODO: add new attacksystem

    private void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();

        unitInput = unitSettings.IsPlayer ? new PlayerController() as IUnitInput : new SlimeController();
        jumpSystem = new JumpSystem(unitSettings);

        state = new UnitState(rb, unitInput, jumpSystem);

        motor = new UnitMotor(unitInput, state, rb, unitSettings);

        if (cam != null)
        {
            camInput = new PlayerController();
            camMotor = new PlayerCamMotor(camInput, GetComponent<Transform>(), cam, unitSettings);
        }
    }
    
    private void Update()
    {
        unitInput.readInput();
        if (cam != null)
            camInput.readInput();

        state.tick();
        jumpSystem.tick();
    }

    private void FixedUpdate()
    {
        motor.tickFixed();
        if (cam != null)
            camMotor.tickFixed();
    }

    private void OnCollisionStay(Collision collision)
    {
        
    }
}
