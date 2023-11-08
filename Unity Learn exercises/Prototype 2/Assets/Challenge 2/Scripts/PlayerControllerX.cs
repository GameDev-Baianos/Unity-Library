using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    private float delay = 0.5f;
    private bool isCooldown = false;

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog in a delay interval
        if (Input.GetKeyDown(KeyCode.Space) && !isCooldown)
        {
            StartCoroutine(instantiateDelay(delay));
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
        }
    }

    private IEnumerator instantiateDelay(float delay)
    {
        isCooldown = true;
        yield return new WaitForSeconds(delay);
        isCooldown = false;
    }
}
