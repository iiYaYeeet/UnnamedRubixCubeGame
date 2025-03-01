using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercont : MonoBehaviour
{
    public Rigidbody RB;
    public float maxspeed;
    public float movespeed;
    public float jump;

    public void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            RB.AddForce(transform.right*movespeed/10,ForceMode.Impulse);
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            RB.AddForce(transform.right*-movespeed/10,ForceMode.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            RB.AddForce(transform.up*jump,ForceMode.Impulse);
        }
        
        if (RB.velocity.magnitude > maxspeed)
        {
            RB.drag = 4;
        }
    }
}
