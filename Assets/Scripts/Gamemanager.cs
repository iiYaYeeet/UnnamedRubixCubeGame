using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    #region Declerations

        #region Enums
        public enum State
        {
            playerControlled,
            cubeControlled
        }
        [SerializeField] public State GameState = State.playerControlled;
        #endregion

        [Header("Lists")] 
        public List<BoxCollider> playerColliders;
        public List<BoxCollider> ControlColliders;

        public Quaternion heldrotation;
        public GameObject portal;
        public List<GameObject> fakeportals;
        public bool firstswitch;
        public AudioSource AS;
        public AudioClip Space;
        public AudioClip cubeexit;
        
    #endregion
    #region Static Class setup
    public static class God
    {
        public static Gamemanager GM;
        public static playercont PC;
        public static Cubecontrolle CC;
        public static Cameracont CaC;
    }
    public void Start()
    {
        Application.targetFrameRate = 60;
        God.GM = this;
    }
    #endregion

    public void switchState()
    {
        if (GameState == State.playerControlled)
        {
            if (!firstswitch)
            {
                portal.SetActive(true);
                firstswitch = true;
            }

            heldrotation = God.CC.transform.rotation;
            God.CC.transform.rotation = Quaternion.Euler(0,0,0);
            GameState = State.cubeControlled;
            God.PC.playercontrol = false;
            God.PC.gravitymult = 0;
            God.PC.RB.constraints = RigidbodyConstraints.FreezeAll;
            God.PC.SR.enabled = false;
            foreach (BoxCollider collider in playerColliders)
            {
                collider.enabled = false;
            }
            foreach (BoxCollider collider in ControlColliders)
            {
                collider.enabled = true;
            }
        }
        else if (GameState == State.cubeControlled)
        { 
            God.CC.transform.rotation = heldrotation;
           GameState = State.playerControlled;
           God.PC.playercontrol = true;
           God.PC.gravitymult = 1;
           God.PC.RB.constraints = RigidbodyConstraints.None;
           God.PC.RB.constraints = RigidbodyConstraints.FreezeRotation;
           God.PC.SR.enabled = true;
           foreach (BoxCollider collider in playerColliders)
           {
               collider.enabled = true;
           }
           foreach (BoxCollider collider in ControlColliders)
           {
               collider.enabled = false;
           }
           God.PC.Playercammovement(God.PC.currentbox);
        }
    }
}
