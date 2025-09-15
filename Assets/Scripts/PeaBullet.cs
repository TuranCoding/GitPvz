using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeaBullet : MonoBehaviour
{
    public Vector3 direction;
    public float speed;

    void Start()
    {

    }

    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }
    
}
