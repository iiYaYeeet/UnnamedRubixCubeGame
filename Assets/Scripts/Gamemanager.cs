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
        God.GM = this;
    }
    #endregion

    public void switchState()
    {
        if (GameState == State.playerControlled)
        {
            GameState = State.cubeControlled;
            God.PC.playercontrol = false;
        }
        else if (GameState == State.cubeControlled)
        {
           GameState = State.playerControlled;
           God.PC.playercontrol = true;
           God.PC.Playercammovement(God.PC.currentbox);
        }
    }
}
