using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class PlayerMotor : MonoBehaviour
{
    private Camera cam;
    [SerializedField]
    private Position attachedObjectPosition;
    
    private Vector3 camRotation = Vector3.zero;
    // TODO: add property to the above

    private void Start()
    {
        cam = GetComponent<Camera>();
    }
    
    private void FixedUpdate()
    {
        performRotation();
    }


    private void performRotation()
    {
        cam.transform.RotateAround(attachedObjectPosition, transform.right, camRotation.x); 
    }
}
