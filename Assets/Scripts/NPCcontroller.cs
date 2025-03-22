using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCcontroller : MonoBehaviour
{
    
    public enum NPC
    {
        Robot,
        Cultist,
        Band,
        Engineer,
        Cakeboy,
    }
    [SerializeField] public NPC type = NPC.Robot;

    public void Update()
    {
        switch (type)
        {
            case NPC.Robot:
                if (Input.GetKeyDown(KeyCode.E)&& Gamemanager.God.PC.interact)
                {
                    if (Gamemanager.God.PC.heldobj.name == "Gear")
                    {
                        Debug.Log("yippiee");
                        tag = "Pickup";
                        Gamemanager.God.PC.heldobj = null;
                        Gamemanager.God.PC.interact = false;
                    }
                }
                break;
        }
    }
}
