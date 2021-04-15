using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFov : MonoBehaviour
{

    [SerializeField] private PlayerMovement_transform p;

    Camera cam;

    private void Start()
    {
        cam = transform.GetComponent<Camera>();
    }

    private void Update()
    {
        if(p.GetSpeed() > 42)
        {
            cam.fieldOfView = 70;
        }
        else if(p.GetSpeed() > 47)
        {
            cam.fieldOfView = 75;
        }
        else
        {
            cam.fieldOfView = 65;
        }
    }

}
