using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    private enum RotationAxes
    {
        MouseXAndY = 0,
        MouseX = 1,
        MouseY = 2
    }
    [SerializeField] private RotationAxes axes;
    [SerializeField] private float sensetiveHorizontal = 9.0f;
    [SerializeField] private float sensetiveVertical = 5.0f;
    private Vector3 cameraRotation = Vector3.zero;

    private float minVerticalAngel = -35.0f;
    private float maxVerticalAngel = 35.0f;

    //private float rotationX = 0f;

    private void Update()
    {
        if (axes == RotationAxes.MouseX)
        {
            // vertical way
            transform.Rotate(0f, Input.GetAxis("Mouse X") * sensetiveHorizontal, 0f);
        }
        else if (axes == RotationAxes.MouseY)
        {
            // horizontal way
            cameraRotation.x -= Input.GetAxis("Mouse Y") * sensetiveVertical;
            cameraRotation.x = Mathf.Clamp(cameraRotation.x, minVerticalAngel, maxVerticalAngel);

            cameraRotation.y = transform.localEulerAngles.y;
            transform.localEulerAngles = cameraRotation;
        }
        else
        {
            // combined way
        }
    }
}
