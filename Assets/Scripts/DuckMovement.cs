using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckMovement : MonoBehaviour
{
    [SerializeField] float speed = 20f;
    [SerializeField] float frequency = 1f;
    [SerializeField] float amplitude = 1f;
    Vector3 previousPosition;
    Vector3 currentPosition;

    // Start is called before the first frame update
    void Start()
    {
        previousPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        currentPosition = Vector3.up * Mathf.Sin(Time.time * frequency) * amplitude;
        currentPosition += (previousPosition.x * Vector3.right) + Vector3.right * speed * Time.deltaTime;
        transform.position = currentPosition;
        previousPosition = currentPosition;
    }
}