using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] private float sensetiveY = 1f;
    [SerializeField] private float sensetiveX = 2f;
    private float mouseX;
    private float mouseY;

    private void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * sensetiveX * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * sensetiveY * Time.deltaTime;

        this.transform.Rotate(0, mouseX, mouseY);
    }
}
