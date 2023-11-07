using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float horizontalnput;
    float moveSpeed = 15.0f;
    float xRange = 15;

    public GameObject projectilePrefab;

    // Update is called once per frame
    void FixedUpdate()
    {
        // Keep player in map
        if(transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if(transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
 
        horizontalnput = Input.GetAxisRaw("Horizontal");
        transform.Translate(Vector3.right * moveSpeed * Time.fixedDeltaTime * horizontalnput);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
    }
}
