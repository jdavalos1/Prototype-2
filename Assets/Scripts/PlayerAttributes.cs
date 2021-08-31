using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttributes : MonoBehaviour
{
    private int health = 3;
    private int score = 0;

    public void IncreaseScore()
    {
        score++;
        Debug.Log($"Score: {score}");
    }

    public void DecreaseHealth()
    {
        health--;

        Debug.Log($"Health: {health}");
        if(health < 1)
        {
            Debug.Log("Game Over");
            Destroy(gameObject);
        }
    }
}
