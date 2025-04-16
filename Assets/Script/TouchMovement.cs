using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchMovement : MonoBehaviour
{
   public Transform playerBody; // For horizontal (Y) rotation
    public float sensitivity = 0.1f;
    public float xRotation = 0f;

    private int lookFingerId = -1;

    void Update()
    {
        foreach (Touch touch in Input.touches)
        {
            // New touch begins
            if (touch.phase == TouchPhase.Began)
            {
                // Only assign finger if on right half of screen
                if (touch.position.x > Screen.width / 2 && lookFingerId == -1)
                {
                    lookFingerId = touch.fingerId;
                }
            }

            // Handle touch movement for look
            if (touch.fingerId == lookFingerId)
            {
                if (touch.phase == TouchPhase.Moved)
                {
                    Vector2 delta = touch.deltaPosition;

                    float mouseX = delta.x * sensitivity;
                    float mouseY = delta.y * sensitivity;

                    // X rotation (pitch)
                    xRotation -= mouseY;
                    xRotation = Mathf.Clamp(xRotation, -80f, 80f);
                    transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

                    // Y rotation (yaw)
                    playerBody.Rotate(Vector3.up * mouseX);
                }

                // Release finger
                if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
                {
                    lookFingerId = -1;
                }
            }
        }
    }
}
  





