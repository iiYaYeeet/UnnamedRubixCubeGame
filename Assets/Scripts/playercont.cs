using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercont : MonoBehaviour
{
    [Header("Components")]
    public Rigidbody RB;
    public Animator anim;
    //[Header("Ints")]
    //Ints
    [Header("Bools")]
    public bool playercontrol;
    public bool grounded;
    public bool wall;
    public bool right;
    [Header("Floats")]
    [Tooltip("Max player move speed")]public float maxspeed;
    [Tooltip("Player speed applied every frame")]public float movespeed;
    [Tooltip("jump force applied")]public float jump;
    //[Header("Lists")]
    //lists
    [Header("Objects")]
    [Tooltip("Current face player is on")]public GameObject currentbox;
    [Tooltip("Target for the camera to start at")]public Transform camtarget;

    public GameObject bottomcol;
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
            if (grounded)
            {
                if (!wall)
                {
                    anim.SetBool("walk", true);
                    RB.AddForce(transform.right * movespeed, ForceMode.Force);
                }
            }
            else
            {
                if (!wall)
                {
                    anim.SetBool("walk", false);
                    RB.AddForce(transform.right * movespeed/5, ForceMode.Force);
                }
            }
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            if (grounded)
            {
                if (!wall)
                {
                    anim.SetBool("walk", true);
                    RB.AddForce(transform.right * -movespeed, ForceMode.Force);
                }
            }
            else
            {
                if (!wall)
                {
                    anim.SetBool("walk", false);
                    RB.AddForce(transform.right * -movespeed/5, ForceMode.Force);
                }
            }
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            anim.SetBool("walk", false);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            anim.SetBool("walk", false);
        }
        anim.SetFloat("speed", Mathf.Abs(RB.velocity.magnitude/2));
        if (wall)
        {
            RB.drag = 1;
        }
        else
        {
            RB.drag = 0.5f;
        }
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (grounded)
            {
                RB.AddForce(transform.up*jump,ForceMode.Impulse);
            }
            if (wall)
            {
                if (right)
                {
                    RB.AddForce(transform.right*-jump/1.5f, ForceMode.Impulse);
                }
                else
                {
                    RB.AddForce(transform.right*jump/1.5f, ForceMode.Impulse);
                }
                RB.AddForce(transform.up*jump/4,ForceMode.Impulse);
            }
        }
        #endregion
        #region Physics calcs
        //
        Debug.DrawRay(transform.position, -transform.right, Color.green);
        Debug.DrawRay(transform.position, transform.right, Color.green);
        #endregion
    }

    public void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            Collider[] bcols = Physics.OverlapBox(bottomcol.transform.position, bottomcol.transform.lossyScale, bottomcol.transform.rotation);
            RaycastHit hit;
            if (Physics.Raycast(transform.position, -transform.right, out hit, transform.localScale.magnitude+0.01f))
            {
                right = false;
                wall = true;
                grounded = false;
            }
            if (Physics.Raycast(transform.position, transform.right, out hit, transform.localScale.magnitude+0.01f))
            { 
                right = true;
                wall = true;
                grounded = false;
            }
            if (bcols.Length > 0)
            {
                grounded = true;
            }
        }
    }
    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            wall = false;
            grounded = false;
        }
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
