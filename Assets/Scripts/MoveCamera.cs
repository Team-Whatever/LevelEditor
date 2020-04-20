using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [SerializeField] float cameraMovementSpeed = 10.0f;
    [SerializeField] float cameraSpeedShiftMultiplier = 3.0f;
    [SerializeField] float horizontalRotationSpeed = 2.0f;
    [SerializeField] float verticalRotationSpeed = 2.0f;

    private float defaultCameraMovementSpeed;
    private float cameraYaw = 0.0f;
    private float cameraPitch = 0.0f;

    private void Start()
    {
        defaultCameraMovementSpeed = cameraMovementSpeed;
    }

    void Update()
    {
        // Mousebutton(1) is the right mouse, '0' would be left mouse.
        if (Input.GetMouseButton(1))
        {
            MouseMovement();
            KeyboardMovement();
        }
    }

    private void KeyboardMovement()
    {
        if (Input.GetKey(KeyCode.LeftShift))
            cameraMovementSpeed = defaultCameraMovementSpeed * cameraSpeedShiftMultiplier;
        else
            cameraMovementSpeed = defaultCameraMovementSpeed;

        if (Input.GetKey(KeyCode.W)){ transform.Translate(Vector3.forward * cameraMovementSpeed * Time.deltaTime); }
        if (Input.GetKey(KeyCode.S)){ transform.Translate(Vector3.back * cameraMovementSpeed * Time.deltaTime); }
        if (Input.GetKey(KeyCode.A)){ transform.Translate(Vector3.left * cameraMovementSpeed * Time.deltaTime); }
        if (Input.GetKey(KeyCode.D)){ transform.Translate(Vector3.right * cameraMovementSpeed * Time.deltaTime); }
    }

    void MouseMovement()
    {
        cameraYaw += horizontalRotationSpeed * Input.GetAxis("Mouse X");
        cameraPitch -= verticalRotationSpeed * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(cameraPitch, cameraYaw, 0.0f);
    }
}
