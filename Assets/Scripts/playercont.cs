using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class playercont : MonoBehaviour
{
    [Header("Components")]
    public Rigidbody RB;
    public SpriteRenderer SR;
    public Animator anim;
    [Header("Bools")]
    public bool playercontrol;
    public bool grounded;
    public bool wall;
    public bool right;
    public bool interact;
    public bool moving;
    public bool jumping;
    public bool poisoned;
    public bool water;
    [Header("Floats")]
    [Tooltip("Max player move speed")]public float maxspeed;
    [Tooltip("Player speed applied every frame")]public float movespeed;
    [Tooltip("Jump force applied")]public float jump;
    public float timer;
    public float gravitymult;
    [Header("Objects")]
    [Tooltip("Current face player is on")]public GameObject currentbox;
    [Tooltip("Target for the camera to start at")]public Transform camtarget;
    [Tooltip("Bottom overlapbox for player")]public GameObject bottomcol;
    public GameObject heldobj;
    [Header("Audio")] 
    public AudioSource AS;
    public AudioClip Jump;
    public AudioClip Pickup;
    public AudioClip Give;
    public void Start()
    {
        Gamemanager.God.PC = this;
    }

    public void FixedUpdate()
    {
        #region Physics calcs
        //Gravity
        RB.AddForce(Physics.gravity * gravitymult, ForceMode.Acceleration);

        #region Movement

        if (grounded&&!wall&&moving)
        {
            if (right)
            {
                RB.AddForce(transform.right * -movespeed, ForceMode.Acceleration);
            }
            else
            {
                RB.AddForce(transform.right * movespeed, ForceMode.Acceleration);
            }
        }
        else if (!wall&&moving)
        {
            if (right)
            {
                RB.AddForce(transform.right * -movespeed/5, ForceMode.Acceleration);
            }
            else
            {
                RB.AddForce(transform.right * movespeed/5, ForceMode.Acceleration);
            }
        }
        #endregion

        #region Jump

        if (jumping)
        {
            if (grounded)
            {
                RB.AddForce(transform.up * jump, ForceMode.Impulse);
            }

            if (wall)
            {
                if (right)
                {
                    RB.AddForce(transform.right * jump / 1.5f, ForceMode.Impulse);
                }
                else
                {
                    RB.AddForce(transform.right * -jump / 1.5f, ForceMode.Impulse);
                }

                RB.AddForce(transform.up * jump / 4, ForceMode.Impulse);
            }
        }

        #endregion

        transform.position = new Vector3(31.7f, transform.position.y, transform.position.z);

        #endregion
    }

    public void Update()
    {
        #region cubeexit
        if (Gamemanager.God.GM.GameState == Gamemanager.State.cubeControlled)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                transform.position = Gamemanager.God.GM.portal.transform.position;
                Gamemanager.God.GM.switchState();
                if (right)
                {
                    RB.AddForce(transform.right*jump/2, ForceMode.Impulse);
                    gravitymult = 1f;
                }
                else
                {
                    RB.AddForce(transform.right*-jump/2, ForceMode.Impulse);
                    gravitymult = 1f;
                }
                RB.AddForce(transform.up*jump/4,ForceMode.Impulse);
            }
        }
        #endregion
        #region Input
        #region a/d movement
        if (Input.GetKey(KeyCode.D))
        {
            if (grounded)
            {
                if (!wall)
                {
                    right=false;
                    moving = true;
                    anim.SetBool("walk", true);
                }
            }
            else
            {
                if (!wall)
                {
                    right=false;
                    moving = true;
                    anim.SetBool("walk", false);
                }
            }
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            if (grounded)
            {
                if (!wall)
                {
                    right=true;
                    moving = true;
                    anim.SetBool("walk", true);
                }
            }
            else
            {
                if (!wall)
                {
                    right=true;
                    moving = true;
                    anim.SetBool("walk", false);
                }
            }
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            moving = false;
            anim.SetBool("walk", false);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            moving = false;
            anim.SetBool("walk", false);
        }
        #endregion
        #region Left/Right flip
        if (right)
        {
            transform.localScale = new Vector3(-0.62877f, 0.62877f, 0.62877f);
        }
        else
        {
            transform.localScale = new Vector3(0.62877f, 0.62877f, 0.62877f);
        }
        #endregion
        
        #region speed/wall alts
        anim.SetFloat("speed", Mathf.Abs(RB.velocity.magnitude/2));
        
        if (wall)
        {
            RB.drag = 1;
        }
        else
        {
            RB.drag = 0.5f;
        }
        #endregion
        #region jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumping = true;
            if (grounded)
            {
                gravitymult = 1f;
                AS.PlayOneShot(Jump);
            }
            if (wall)
            {
                if (right)
                {
                    gravitymult = 1f;
                    AS.PlayOneShot(Jump);
                }
                else
                {
                    gravitymult = 1f;
                    AS.PlayOneShot(Jump);
                }
                RB.AddForce(transform.up*jump/4,ForceMode.Impulse);
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            jumping = false;
        }
        #endregion
        #endregion

        #region Object Manipulation
        if (heldobj != null)
        {
            heldobj.transform.rotation = transform.rotation;
            heldobj.transform.position = Vector3.MoveTowards(heldobj.transform.position, transform.position, 0.01f*Vector3.Distance(transform.position, heldobj.transform.position));
        }

        if (Input.GetKeyDown(KeyCode.E) && interact)
        {
            AS.PlayOneShot(Give);
        }
        #endregion

        #region poison

        if (poisoned)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                transform.position = Gamemanager.God.GM.portal.transform.position;
                poisoned = false;
                timer = 5;
            }
        }

        #endregion
    }

    #region collisons
    public void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            Collider[] bcols = Physics.OverlapBox(bottomcol.transform.position, bottomcol.transform.lossyScale, bottomcol.transform.rotation);
            RaycastHit hit;
            if (Physics.Raycast(transform.position, -transform.right, out hit, transform.localScale.magnitude+0.01f))
            {
                right = true;
                wall = true;
                grounded = false;
                if (water)
                {
                    gravitymult = 0.1f;
                }
                else
                {
                    gravitymult = 0.5f;
                }
                anim.SetBool("wall", true);
            }
            if (Physics.Raycast(transform.position, transform.right, out hit, transform.localScale.magnitude+0.01f))
            { 
                right = false;
                wall = true;
                grounded = false;
                if (water)
                {
                    gravitymult = 0.1f;
                }
                else
                {
                    gravitymult = 0.5f;
                }
                anim.SetBool("wall", true);
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
            if (water)
            {
                gravitymult = 0.25f;
            }
            else
            {
                gravitymult = 1f;
            }
            wall = false;
            grounded = false;
            anim.SetBool("wall", false);
        }
    }
    
    public void OnTriggerEnter(Collider other)
    {
        if (playercontrol)
        {
            if (other.CompareTag("Camtarg"))
            {
                Playercammovement(other.gameObject);
            }
        }

        if (other.gameObject.CompareTag("Pickup"))
        {
            AS.PlayOneShot(Pickup);
            heldobj = other.gameObject;
            other.enabled=false;
        }
        if (other.gameObject.CompareTag("Portal"))
        {
            Gamemanager.God.GM.switchState();
        }
        if (other.gameObject.CompareTag("QuestNPC"))
        {
            interact = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("QuestNPC"))
        {
            interact = false;
        }
    }

    #endregion
    public void Playercammovement(GameObject curbox)
    {
        currentbox = curbox.gameObject;
        if (!curbox.name.Contains("Yellow"))
        {
            poisoned = false;
            timer = 5;
            SR.color=Color.white;
        }
        else
        {
            SR.color=Color.magenta;
        }
        if (curbox.name.Contains("Blue"))
        {
            Gamemanager.God.CaC.wateroverlay.SetActive(true);
            gravitymult = 0.25f;
            jump = 4;
            movespeed = 6;
            water = true;
        }
        else
        {
            gravitymult = 1;
            jump = 6;
            movespeed = 10;
            water = false;
        }
        Gamemanager.God.CaC.camtarget = currentbox.transform.Find("Target");
        Gamemanager.God.CaC.StartCoroutine(nameof(Cameracont.cameramove));
    }
}
