using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercont : MonoBehaviour
{
    [Header("Components")]
    public Rigidbody RB;
    public Camera cam;
    //[Header("Ints")]
    //Ints
    [Header("Floats")]
    [Tooltip("Max player move speed")]public float maxspeed;
    [Tooltip("player speed applied every frame")]public float movespeed;
    [Tooltip("jump force applied")]public float jump;
    //[Header("Lists")]
    //lists
    [Header("Objects")]
    [Tooltip("Current face player is on")]public GameObject currentbox;
    [Tooltip("target for the camera to start at")]public Transform camtarget;
    //[Header("Audio")]
    //Audio

    public void Update()
    {
        #region Input
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
        #endregion
        #region Physics calcs
        if (RB.velocity.magnitude > maxspeed)
        {
            RB.drag = 4;
        }
        #endregion
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
            cam.transform.position=Vector3.Lerp(cam.transform.position,camtarget.transform.position,0.05f);
            cam.transform.LookAt(camtarget.transform.parent,camtarget.transform.up);
            transform.rotation = camtarget.transform.rotation;
            yield return new WaitForFixedUpdate();
        }
    }
}
