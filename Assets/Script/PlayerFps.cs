using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerFps : MonoBehaviour
{
    public CharacterController controller;
    public FloatingJoystick joystick;

    public float speed = 5f;
    public float sprintMultiplier = 1.5f;

    private Vector3 move;
    private bool isSprinting = false;

    void Update()
    {
        // Sprint input (PC version: hold Left Shift)
        isSprinting = Input.GetKey(KeyCode.LeftShift); // <-- replace this for mobile input if needed

        float x = joystick.Horizontal;
        float z = joystick.Vertical;

        // Directional movement
        move = transform.right * x + transform.forward * z;

        // Apply sprint multiplier
        float currentSpeed = isSprinting ? speed * sprintMultiplier : speed;

        controller.Move(move * currentSpeed * Time.deltaTime);
    }
}
