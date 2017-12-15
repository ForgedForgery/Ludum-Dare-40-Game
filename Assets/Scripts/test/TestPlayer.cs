using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TestPlayerMotor))]
public class TestPlayer : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float lookSensitivity = 3f;

    private ITestPlayerInput playerInput;
    private TestPlayerMotor motor;

    private void Start()
    {
        playerInput = new TestPlayerController();
        motor = new TestPlayerMotor(playerInput, transform);
    }

    private void Update()
    {
        playerInput.readInput();
        motor.tick();
    
        movePlayerWithWASD();
        moveCamWithMouse();
    }

    private void movePlayerWithWASD()
    {
        float _xMov = Input.GetAxisRaw("Horizontal");
        float _zMov = Input.GetAxisRaw("Vertical");

        Vector3 _movHorizontal = transform.right * _xMov;
        Vector3 _movVertical = transform.forward * _zMov;

        Vector3 _velocity = (_movHorizontal + _movVertical).normalized * speed;

        motor.setMovement(_velocity);
    }

    private void moveCamWithMouse()
    {
        rotatePlayer();
        rotateCamAroundPlayer();
    }

    private void rotatePlayer()
    {
        float _yRot = Input.GetAxisRaw("Mouse X");
        Vector3 _rotation = new Vector3(0f, _yRot, 0f) * lookSensitivity;

        motor.setRotation(_rotation);
    }

    private void rotateCamAroundPlayer()
    {
        float _xRot = Input.GetAxisRaw("Mouse Y");
        Vector3 _camRotation = new Vector3(-_xRot, 0f, 0f) * lookSensitivity;

        motor.setCamRotation(_camRotation);
    }
}
