using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    float enemySpeed = 15.0f;
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * enemySpeed);
    }
}
