using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercont : MonoBehaviour
{
    [Header("Components")]
    public Rigidbody RB;
    //[Header("Ints")]
    //Ints
    [Header("Bools")]
    public bool playercontrol;
    [Header("Floats")]
    [Tooltip("Max player move speed")]public float maxspeed;
    [Tooltip("Player speed applied every frame")]public float movespeed;
    [Tooltip("jump force applied")]public float jump;
    //[Header("Lists")]
    //lists
    [Header("Objects")]
    [Tooltip("Current face player is on")]public GameObject currentbox;
    [Tooltip("Target for the camera to start at")]public Transform camtarget;
    //[Header("Audio")]
    //Audio
    public void Start()
    {
        Gamemanager.God.PC = this;
    }
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
        if (playercontrol)
        {
            Playercammovement(other.gameObject);
        }
    }

    public void Playercammovement(GameObject curbox)
    {
        currentbox = curbox.gameObject;
        Gamemanager.God.CaC.camtarget = currentbox.transform.Find("Target");
        Gamemanager.God.CaC.StartCoroutine(nameof(Cameracont.cameramove));
    }
}
