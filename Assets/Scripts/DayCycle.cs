using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayCycle : MonoBehaviour
{
    public float speed = 50.0f;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(Vector3.left * speed * Time.deltaTime);
    }
}
