using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float horizontalnput, verticalInput;
    float moveSpeed = 20.0f;
    float xAxis = 1.0f;
    float zAxis = 0.75f;
    float xRange = 15.0f;
    float zMin = -1.0f;
    float zMax = 15.0f;

    public GameObject projectilePrefab;

    // Update is called once per frame
    void FixedUpdate()
    {
        OnMove();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
    }

    void OnMove()
    {
        // Keep player in map
        if(transform.position.x < -xRange)
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        if(transform.position.x > xRange)
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        if(transform.position.z > zMax)
            transform.position = new Vector3(transform.position.x, transform.position.y, zMax);
        if(transform.position.z < zMin)
            transform.position = new Vector3(transform.position.x, transform.position.y, -1);
 
        // Inputs
        horizontalnput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        transform.Translate(Vector3.right * xAxis * moveSpeed * Time.fixedDeltaTime * horizontalnput);
        transform.Translate(Vector3.forward * zAxis * moveSpeed * Time.fixedDeltaTime * verticalInput);
    }
}
