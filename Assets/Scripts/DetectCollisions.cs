using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    private string playerTag = "Player";
    private string spawnTag = "Spawn";
    private string projectileTag = "Projectile";

    // Start is called before the first frame update
    void Start()
    {
    }

    void OnTriggerEnter(Collider other)
    {
        // If the player and spawn have hit collided then decrease the health
        if(other.CompareTag(playerTag) && transform.CompareTag(spawnTag))
        {
            GameObject.Find("Player").GetComponent<PlayerAttributes>().DecreaseHealth();
        }
        // If the spawn and projectile have collide each other delete them and increase score
        if(other.CompareTag(spawnTag) && transform.CompareTag(projectileTag))
        {
            other.GetComponent<SpawnAttributes>().DecreaseHunger();
            Destroy(gameObject);
        }
    }
}
