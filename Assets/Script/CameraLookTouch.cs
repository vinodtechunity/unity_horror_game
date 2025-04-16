using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class CameraLookTouch : MonoBehaviour
{
    public float lookSpeed = 0.2f;
    public FixedJoystick joystick; // Reference to detect joystick touch area

    private int joystickFingerId = -1;

    void Update()
    {
        foreach (Touch touch in Input.touches)
        {
            // Detect joystick touch
            if (IsJoystickTouch(touch))
            {
                if (joystickFingerId == -1)
                    joystickFingerId = touch.fingerId;
                continue;
            }

            // Skip the joystick finger
            if (touch.fingerId == joystickFingerId)
                continue;

            // Rotate camera with other touch
            if (touch.phase == TouchPhase.Moved)
            {
                Vector2 delta = touch.deltaPosition;
                float yaw = delta.x * lookSpeed;
                float pitch = -delta.y * lookSpeed;

                // Rotate player horizontally
                transform.Rotate(0, yaw, 0);

                // Rotate camera vertically
                Camera.main.transform.Rotate(pitch, 0, 0);
            }
        }

        // Reset when touches end
        if (Input.touchCount == 0)
            joystickFingerId = -1;
    }

    // Approximate check for joystick side (left screen)
    bool IsJoystickTouch(Touch touch)
    {
        // Or improve with RectTransform check if needed
        return touch.position.x < Screen.width / 2;
    }
}


