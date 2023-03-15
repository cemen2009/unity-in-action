using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooter : MonoBehaviour
{
    private Camera _camera;
    private Vector3 point;
    // Start is called before the first frame update
    void Start()
    {
        _camera = GetComponent<Camera>();
        point = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight /  2, 0);   // point = center of screen
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = _camera.ScreenPointToRay(point);  // drop ray from point(center of screen)
            if (Physics.Raycast(ray, out RaycastHit hit))   // hit is struct of data about ray, where is hit
            {
                Debug.Log("Hit " + hit.point);
            }
        }
    }
}
