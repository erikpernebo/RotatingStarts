using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5f;  
    public float distance = 5f;  

    private Vector3 startPosition;
    private float direction = 1; 

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float newPositionX = startPosition.x + direction * distance * Mathf.Sin(Time.time * speed);

        transform.position = new Vector3(newPositionX, transform.position.y, transform.position.z);

        if (Mathf.Abs(transform.position.x - startPosition.x) >= distance)
        {
            direction *= -1;
        }
    }

}
