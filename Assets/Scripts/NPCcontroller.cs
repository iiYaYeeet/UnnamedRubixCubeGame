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
    public Animator anim;
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
                        StartCoroutine(Gamemanager.God.CC.rand());
                        Gamemanager.God.GM.switchState();
                        tag = "Pickup";
                        Gamemanager.God.PC.heldobj = null;
                        Gamemanager.God.PC.interact = false;
                        anim.Play("happy");
                    }
                }
                break;
            case NPC.Cakeboy:
                if (Input.GetKeyDown(KeyCode.E)&& Gamemanager.God.PC.interact)
                {
                    if (Gamemanager.God.PC.heldobj.name == "Cake")
                    {
                        Debug.Log("yippiee");
                        Gamemanager.God.CaC.anim.enabled = true;
                        Gamemanager.God.CaC.anim.Play("Cutscene");
                        //Gamemanager.God.GM.AS.PlayOneShot(Gamemanager.God.GM.cubeexit);
                        Gamemanager.God.PC.heldobj = null;
                        Gamemanager.God.PC.interact = false;
                        anim.Play("happy");
                    }
                }
                break;
            case NPC.Engineer:
                if (Input.GetKeyDown(KeyCode.E)&& Gamemanager.God.PC.interact)
                {
                    if (Gamemanager.God.PC.heldobj.name == "Robot")
                    {
                        Debug.Log("yippiee");
                        StartCoroutine(Gamemanager.God.CC.rand());
                        Gamemanager.God.GM.switchState();
                        Gamemanager.God.PC.heldobj = null;
                        Gamemanager.God.PC.interact = false;
                        anim.Play("happy");
                    }
                }
                break;
            case NPC.Cultist:
                if (Input.GetKeyDown(KeyCode.E)&& Gamemanager.God.PC.interact)
                {
                    if (Gamemanager.God.PC.heldobj.name == "Goat")
                    {
                        Debug.Log("yippiee");
                        StartCoroutine(Gamemanager.God.CC.rand());
                        Gamemanager.God.GM.switchState();
                        Gamemanager.God.PC.heldobj = null;
                        Gamemanager.God.PC.interact = false;
                        anim.Play("happy");
                    }
                }
                break;
            case NPC.Band:
                if (Input.GetKeyDown(KeyCode.E)&& Gamemanager.God.PC.interact)
                {
                    if (Gamemanager.God.PC.heldobj.name == "Maracas")
                    {
                        Debug.Log("yippiee");
                        StartCoroutine(Gamemanager.God.CC.rand());
                        Gamemanager.God.GM.switchState();
                        Gamemanager.God.PC.heldobj = null;
                        Gamemanager.God.PC.interact = false;
                        anim.Play("happy");
                    }
                }
                break;
            
        }
    }
}
