using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

#if UNITY_EDITOR

    [SerializeField] private float sensitivity;

    [SerializeField] private bool cameralock = false;
    private Quaternion rot = new Quaternion();

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            cameralock = !cameralock;
        }

        if(cameralock)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        if(cameralock)
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");
            rot.eulerAngles += new Vector3(-mouseY * sensitivity, mouseX * sensitivity, 0.0f);
            transform.rotation = rot;
        }
    }

#endif

}
