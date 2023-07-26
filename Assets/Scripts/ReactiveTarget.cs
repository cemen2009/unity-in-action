using System.Collections;
using UnityEngine;


public class ReactiveTarget : MonoBehaviour
{
    private Rigidbody rb;
    private WanderingAI ai;

    /// <summary>
    /// Object get force applied in the same direction as raycast(bu)
    /// </summary>
    /// <param name="raycastDirection"></param>
    /// <param name="bulletForce"></param>
    public void ReactToHit(Vector3 raycastDirection, float bulletForce)
    {
        rb = GetComponent<Rigidbody>();
        if (rb != null)
            rb.AddForce(raycastDirection * bulletForce, ForceMode.Force);
        
        ai = GetComponent<WanderingAI>();
        if (ai != null)
            ai.SetAlive(false);

        StartCoroutine(Die());
    }

    private IEnumerator Die()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(this.gameObject);
    }
}
