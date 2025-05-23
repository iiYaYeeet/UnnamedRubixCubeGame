using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameracont : MonoBehaviour
{
    #region Declerations
    [Header("Floats")]
    public float maxdistance;
    public float camsens;
    [Header("Components")]
    public Camera cam;
    public Rigidbody RB;
    public Animator anim;
    [Header("Objects")]
    [Tooltip("Target for the camera to start at")]public Transform camtarget;
    [Tooltip("Center of the cube")]public GameObject cubecenter;
    public GameObject wateroverlay;
    #endregion
    
    public void Start()
    {
        Gamemanager.God.CaC = this;
    }

    public void Update()
    {   
        #region Cube driven camera
        if (Gamemanager.God.GM.GameState == Gamemanager.State.cubeControlled)
        {
            #region camera rotation
            Vector3 directionvec = (transform.position - cubecenter.transform.position).normalized;
            #region inputs
            float pull = Input.GetAxis("Mouse ScrollWheel")  * (camsens*200) * Time.deltaTime;
            float xRot = Input.GetAxis("Mouse X") * (camsens*150) * Time.deltaTime;
            float yRot = -Input.GetAxis("Mouse Y") * (camsens*150) * Time.deltaTime;
            Vector3 move = RB.velocity;
            move += transform.forward * pull;
            #endregion
            if (Input.GetMouseButton(0))
            {
                move += transform.up * yRot;
                move -= transform.right * xRot;
            }
            #region calculations
            move += transform.forward * pull;
            RB.velocity = move;
            cam.transform.LookAt(cubecenter.transform);
            //calc distance
            float distance = Vector3.Distance(cam.transform.position, cubecenter.transform.position);
            if (distance > maxdistance)
            {
                //if too far out pull back in
                directionvec = (transform.position - cubecenter.transform.position).normalized;
                RB.AddForce(directionvec*-((distance-maxdistance)/2));
            }
            #endregion
            #endregion
            
            #region side selection

            if (Input.GetMouseButtonDown(1))
            {
                Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                {
                    switch (hit.collider.gameObject.name)
                    {
                        case "White":
                        {
                            Gamemanager.God.CC.rotating.Clear();
                            Gamemanager.God.CC.checkcollision(Gamemanager.God.CC.whiteoverlap);
                            Gamemanager.God.CC.control = 0;
                        }
                            break;
                        case "Red":
                        {
                            Gamemanager.God.CC.rotating.Clear();
                            Gamemanager.God.CC.checkcollision(Gamemanager.God.CC.redoverlap);
                            Gamemanager.God.CC.control = 1;
                        }
                            break;
                        case "Blue":
                        {
                            Gamemanager.God.CC.rotating.Clear();
                            Gamemanager.God.CC.checkcollision(Gamemanager.God.CC.blueoverlap);
                            Gamemanager.God.CC.control = 2;
                        }
                            break;
                        case "Orange":
                        {
                            Gamemanager.God.CC.rotating.Clear();
                            Gamemanager.God.CC.checkcollision(Gamemanager.God.CC.orangeoverlap);
                            Gamemanager.God.CC.control = 3;
                        }
                            break;
                        case "Yellow":
                        {
                            Gamemanager.God.CC.rotating.Clear();
                            Gamemanager.God.CC.checkcollision(Gamemanager.God.CC.yellowoverlap);
                            Gamemanager.God.CC.control = 4;
                        }
                            break;
                        case "Green":
                        {
                            Gamemanager.God.CC.rotating.Clear();
                            Gamemanager.God.CC.checkcollision(Gamemanager.God.CC.greenoverlap);
                            Gamemanager.God.CC.control = 5;
                        }
                            break;
                    }
                }
            }

            #endregion
        }
        #endregion

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //state change
            //Gamemanager.God.GM.switchState();
        }
        
        wateroverlay.transform.Rotate(0.1f,0,0);
    }

    public IEnumerator cameramove()
    {
        while (Vector3.Distance(transform.position, camtarget.position) > 0.05f)
        {
            cam.transform.position=Vector3.Lerp(cam.transform.position,camtarget.transform.position,0.07f);
            transform.rotation = camtarget.transform.localRotation;
            cam.transform.LookAt(camtarget.transform.parent.position,transform.up);
            if (Gamemanager.God.GM.GameState == Gamemanager.State.cubeControlled)
            {
                yield break;
            }
            yield return new WaitForFixedUpdate();
        }
        Debug.Log("cleared");
        transform.rotation = camtarget.transform.localRotation;
    }

    public void randomizecube()
    {
        StartCoroutine(Gamemanager.God.CC.rand());
        Gamemanager.God.GM.AS.Play();
    }

    public void endcutscene()
    {
        Gamemanager.God.GM.switchState();
        anim.enabled = false;
        cam.transform.position = new Vector3(113.6f, 41.6f, -59.8f);
    }
}
