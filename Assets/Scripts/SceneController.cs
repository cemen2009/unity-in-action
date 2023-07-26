using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    private GameObject enemyInstance;
    private float angle;

    private void Update()
    {
        if (enemyInstance == null)
        {
            enemyInstance = Instantiate(enemyPrefab);
            enemyInstance.transform.position = this.transform.position;

            angle = Random.Range(0f, 360f);
            enemyInstance.transform.Rotate(0f, angle, 0f);
        }
    }
}
