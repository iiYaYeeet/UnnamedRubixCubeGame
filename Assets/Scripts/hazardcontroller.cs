using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hazardcontroller : MonoBehaviour
{
    #region Declerations
    [Header("Objects")]
    public Transform quicksandtarg;
    
    public enum Hazard
    {
        Quicksand,
        Lava,
        Poison,
    }
    [SerializeField] public Hazard type = Hazard.Poison;
    
    #endregion

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            switch (type)
            {
                case Hazard.Poison:
                    Gamemanager.God.PC.poisoned = true;
                    Gamemanager.God.PC.timer = 5;
                    break;
                case Hazard.Lava:
                    Gamemanager.God.PC.transform.position = Gamemanager.God.GM.portal.transform.position;
                    break;
                case Hazard.Quicksand:
                    Gamemanager.God.PC.transform.position = quicksandtarg.position;
                    break;
            }
        }
    }
}

