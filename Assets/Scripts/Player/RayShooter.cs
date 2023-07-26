using System.Collections;
using System.Text;
using UnityEngine;

public class RayShooter : MonoBehaviour
{
    private Vector3 point;
    private int size = 12;
    [SerializeField] private float bulletForce = 10f;
    
    private Ray ray;
    private GameObject hitObject;
    private ReactiveTarget target;
    private float posX, posY;
    private Rect sightRect;
    private StringBuilder sight = new StringBuilder("+");

    // Start is called before the first frame update
    void Start()
    {
        posX = Camera.main.pixelWidth / 2 - size / 4;
        posY = Camera.main.pixelHeight / 2 - size / 2;
        sightRect = new Rect(posX, posY, size, size);

        point = new Vector3(Camera.main.pixelWidth / 2, Camera.main.pixelHeight /  2, 0);   // point = center of screen

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            ray = Camera.main.ScreenPointToRay(point);  // drop ray from point(center of screen)
            if (Physics.Raycast(ray, out RaycastHit hit))   // hit is struct of data about ray, where is hit
            {
                hitObject = hit.transform.gameObject;
                target = hitObject.GetComponent<ReactiveTarget>();
                if (target != null)
                    target.ReactToHit(ray.direction, bulletForce);
                else
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
        posX = Camera.main.pixelWidth / 2 - size / 4;
        posY = Camera.main.pixelHeight / 2 - size / 2;
        GUI.Label(new Rect(posX, posY, size, size), "+");
    }
}
