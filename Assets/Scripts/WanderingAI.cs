using UnityEngine;

public class WanderingAI : MonoBehaviour
{
    [SerializeField] private GameObject fireballPrefab;
    private GameObject fireballInstance;

    [SerializeField] private float speed = 3f;
    [SerializeField] private float obstacleRange = 5f;
    private bool isAlive;
    private GameObject hitObject;

    private Ray ray;
    private RaycastHit hit;
    private float angle;

    private void Awake()
    {
        isAlive = true;
    }

    private void Update()
    {
        if (!isAlive)
            return;
        transform.Translate(0f, 0f, speed * Time.deltaTime);

        ray = new Ray(transform.position, transform.forward);
        if (Physics.SphereCast(ray, 0.75f, out hit))
        {
            hitObject = hit.transform.gameObject;
            // if hit object is the player
            if (hitObject.GetComponent<PlayerCharacter>())
            {
                if (fireballInstance == null)
                {
                    fireballInstance = Instantiate(fireballPrefab);
                    fireballInstance.transform.position = this.transform.TransformPoint(Vector3.forward * 1.5f);
                    fireballInstance.transform.rotation = this.transform.rotation;
                }
            }
            else if (hit.distance < obstacleRange)
            {
                angle = Random.Range(-110, 110);
                transform.Rotate(0f, angle, 0f);
            }
        }
    }

    public void SetAlive(bool status)
    {
        isAlive = status;
    }
}
