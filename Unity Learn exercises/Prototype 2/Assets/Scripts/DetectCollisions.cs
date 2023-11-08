using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    private GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.AddLives(-1);
            Destroy(gameObject);
        }
        else 
        {
            gameManager.AddScore(5);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
