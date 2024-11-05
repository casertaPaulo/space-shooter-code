using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2COntroller : EnemyController
{
    // Start is called before the first frame update
    void Start()
    {
       rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0f, speed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }  
}
