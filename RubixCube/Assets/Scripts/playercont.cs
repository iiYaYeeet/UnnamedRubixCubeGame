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
    public GameObject currentbox;
    public Transform camtarget;
    public Camera cam;

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

    public void OnTriggerEnter(Collider other)
    {
        currentbox = other.gameObject;
        StartCoroutine(cameramove());
    }

    public IEnumerator cameramove()
    {
        camtarget = currentbox.transform.Find("Target");
        while (cam.transform.position!=camtarget.transform.position)
        {
            cam.transform.position=Vector3.Lerp(cam.transform.position,camtarget.transform.position,0.2f);
            yield return new WaitForFixedUpdate();
        }
    }
}
