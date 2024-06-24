using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckSpawner : MonoBehaviour
{
    [SerializeField] GameObject duck;
    [SerializeField] float spawnDelay = 1.0f;
    float currentTime = 0.0f;
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime > spawnDelay)
        {
            Instantiate(duck);
            currentTime = 0.0f;
        }
    }
}
