using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* Place this script on an object that will follow the player mouse
* in a 3D environment.
* the Layermask array should be set to everything but the parent object's layer and
* possibly the camera/anything the camera is attached to.
*/

public class MousePosition3D : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private LayerMask surfaces;

    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, surfaces))
        {
            transform.position = raycastHit.point;
        }
    }
}
