using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackAndForth : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    private float maxZ = 16f;
    private float minZ = -16f;

    private int direction = 1;

    private void Update()
    {
        transform.Translate(0f, 0f, direction * speed * Time.deltaTime);

        bool bounced = false;
        if (transform.position.z > maxZ || transform.position.z < minZ)
        {
            direction = -direction;
            bounced = true;
        }
        if (bounced)
        {
            transform.Translate(0f, 0f, direction * speed * Time.deltaTime);
        }
    }
}