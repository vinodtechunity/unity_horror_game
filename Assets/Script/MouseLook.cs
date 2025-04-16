using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseLook : MonoBehaviour
{
    public float MouseSenstivity = 0f;
    public Transform playerBoby;

    float xRotation;


    // Start is called before the first frame update
    void Start()
    {
      //  Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
       float mousex = 0* MouseSenstivity;
        float mousey = 0* MouseSenstivity;
       // float mousex = Input.GetAxis("Mouse X")* MouseSenstivity;
        //float mouseY = Input.GetAxis("Mouse Y")* MouseSenstivity;

        if (Input.touchCount >0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {  if(EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
              return;
            mousex =  Input.GetTouch(0).deltaPosition.x;
            mousey=  Input.GetTouch(0).deltaPosition.y;
        }

        xRotation -= mousey* Time.deltaTime;
        xRotation = Mathf.Clamp (xRotation,-80,80);
        transform.localRotation = Quaternion.Euler(xRotation,0,0);

        playerBoby.Rotate(Vector3.up * mousex * Time.deltaTime);

    }
}
