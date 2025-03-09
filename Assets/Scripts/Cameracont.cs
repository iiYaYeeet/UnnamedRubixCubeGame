using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameracont : MonoBehaviour
{
    [Header("Floats")]
    public float maxdistance;
    public float camsens;
    [Header("Components")]
    public Camera cam;
    public Rigidbody RB;
    [Header("Objects")]
    [Tooltip("Target for the camera to start at")]public Transform camtarget;
    [Tooltip("Center of the cube")]public GameObject cubecenter;
    
    public void Start()
    {
        Gamemanager.God.CaC = this;
    }

    public void Update()
    {   
        #region Cube driven camera
        if (Gamemanager.God.GM.GameState == Gamemanager.State.cubeControlled)
        {
            if (Input.GetMouseButton(0))
            {
                float xRot = Input.GetAxis("Mouse X") * camsens;
                float yRot = -Input.GetAxis("Mouse Y") * camsens;
                //set 0
                Vector3 move = RB.velocity;
                move += transform.up * yRot;
                move -= transform.right * xRot;
                //plug back in
                RB.velocity = move;
            }
            cam.transform.LookAt(cubecenter.transform);
            //calc distance
            float distance = Vector3.Distance(cam.transform.position, cubecenter.transform.position);
            if (distance > maxdistance)
            {
                //if too far out pull back in
                Vector3 directionvec = (transform.position - cubecenter.transform.position).normalized;
                RB.AddForce(directionvec*-((distance-maxdistance)/2));
            }
        }
        #endregion

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //state change
            Gamemanager.God.GM.switchState();
        }
    }

    public IEnumerator cameramove()
    {
        while (Vector3.Distance(transform.position, camtarget.position) > 0.05f)
        {
            cam.transform.position=Vector3.Lerp(cam.transform.position,camtarget.transform.position,0.05f);
            cam.transform.LookAt(camtarget.transform.parent,camtarget.transform.up);
            if (Gamemanager.God.GM.GameState == Gamemanager.State.cubeControlled)
            {
                yield break;
            }
            yield return new WaitForFixedUpdate();
        }
        Debug.Log("cleared");
        transform.rotation = camtarget.transform.rotation;
    }
}
