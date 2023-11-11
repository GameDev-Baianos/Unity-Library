using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalScript : ColliderScript
{
    public string[] sceneNames;
    protected override void OnCollide(Collider2D coll)
    {
        if(coll.name == "Player")
        {
            // Teleport the player to a random scene
            GameManager.instance.SaveState();
            string sceneName = sceneNames[Random.Range(0, sceneNames.Length)];
            SceneManager.LoadScene(sceneName);
        }
    }
}
