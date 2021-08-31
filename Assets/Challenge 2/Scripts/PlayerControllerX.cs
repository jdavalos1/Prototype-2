using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    public float timeDelay;
    private float timeStamp = 0;

    // Update is called once per frame
    void Update()
    {
        float currentTime = Time.time;
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && currentTime >= timeStamp)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            timeStamp = currentTime + timeDelay;
        }
    }
}
