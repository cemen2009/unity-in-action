using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    private ushort damage = 1;

    private void Update()
    {
        transform.Translate(0f, 0f, speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerCharacter player = other.GetComponent<PlayerCharacter>();
        if (player != null)
        {
            player.GetDamage(damage);
        }
        Destroy(this.gameObject);

    }
}
