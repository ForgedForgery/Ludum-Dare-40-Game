using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class UnitComponent : MonoBehaviour
{
    [SerializeField]
    private Camera cam;
    [SerializeField]
    private UnitSettings settings;

    private Rigidbody rb;

    private UnitLogic unit;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        unit = new UnitLogic(settings);
    }

    private void Update()
    {
        // TODO:
        // needs to be different
        // should check for collission with ground or something similar
        if (rb.transform.position.y <= 0.51f)
            unit.OnLand();
        unit.Tick();
    }

    private void FixedUpdate()
    {
        performMove();
        performRotation();
        if (unit.Jumping)
            performJump();
    }

    private void performMove()
    {
        Vector3 sideVector = rb.transform.right * unit.SideMove;
        Vector3 forwardVector = rb.transform.forward * unit.ForwardMove;
        Vector3 destination = (sideVector + forwardVector).normalized * settings.MovementSpeed;
        if (destination != Vector3.zero)
        {
            rb.MovePosition(rb.position + destination * Time.fixedDeltaTime);
        }
    }

    private void performRotation()
    {
        Vector3 rotation = new Vector3(0f, unit.SideRotation, 0f) * settings.MovementSpeed;
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));
    }

    private void performJump()
    {
        unit.usedJump();

        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(rb.transform.up * settings.JumpForce, ForceMode.Impulse);
    }

    private void performCamRotation()
    {
        float rotationAngle = -unit.HorizontalCamRotation * settings.LookSensitivity;
        cam.transform.RotateAround(rb.transform.position, rb.transform.right, rotationAngle);
    }
}
