using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooter : MonoBehaviour
{
    private Camera _camera;
    private Vector3 point;
    private int size = 12;

    // Start is called before the first frame update
    void Start()
    {
        _camera = GetComponent<Camera>();
        point = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight /  2, 0);   // point = center of screen

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = _camera.ScreenPointToRay(point);  // drop ray from point(center of screen)
            if (Physics.Raycast(ray, out RaycastHit hit))   // hit is struct of data about ray, where is hit
            {
                StartCoroutine(SphereIndicator(hit.point));
            }
        }
    }

    private IEnumerator SphereIndicator(Vector3 position)
    {
        // create sphere and give it position of hit
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = position;
        
        // sphere exists one second
        yield return new WaitForSeconds(1);

        // and destroys
        Destroy(sphere);
    }

    private void OnGUI()
    {
        float posX = _camera.pixelWidth / 2 - size / 4;
        float posY = _camera.pixelHeight / 2 - size / 2;
        GUI.Label(new Rect(posX, posY, size, size), "+");
    }
}
