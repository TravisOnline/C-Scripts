using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePosition3D : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private LayerMask surfaces;
    public bool canBuildMouse;

    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, surfaces))
        {
            canBuildMouse = true;
            transform.position = raycastHit.point;
            //Need to calculate position from hit object, add or remove by 1
        }
        else
        {
            canBuildMouse = false;
        }
    }
}
