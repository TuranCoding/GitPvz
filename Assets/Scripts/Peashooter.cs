using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peashooter : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;

    public float interval;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Attack();

    }

    public void Attack()
    {
        timer += Time.deltaTime;
        if (timer > interval)
        {
            timer = 0;
            Instantiate(bullet,bulletPos.position,Quaternion.identity);
        }
        
    }
}
