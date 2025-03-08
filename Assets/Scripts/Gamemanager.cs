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
        State GameState = State.playerControlled;
        #endregion
        
    #endregion
    #region Static Class setup
    public static class God
    {
        public static Gamemanager GM;
        public static playercont PC;
        public static Cubecontrolle CC;
    }
    public void Start()
    {
        God.GM = this;
    }
    #endregion

    public void Update()
    {
        #region StateManagement;

        //manage state

        #endregion
    }

    public void switchState()
    {
        if (GameState == State.playerControlled)
        {
            GameState = State.cubeControlled;
        }

        if (GameState == State.cubeControlled)
        {
           GameState = State.playerControlled; 
        }
    }
}
