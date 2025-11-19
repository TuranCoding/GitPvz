using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PeaBullet : MonoBehaviour
{
    public Vector3 direction;
    public float speed;

    void Start()
    {
        Debug.Log("习惯就好");

    }

    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }
    
}
