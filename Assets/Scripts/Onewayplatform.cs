using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Onewayplatform : MonoBehaviour
{
    
    public BoxCollider floor;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            floor.enabled = false;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            floor.enabled = true;
        }
    }

    public void Update()
    {
        if (Vector3.Distance(transform.position, Gamemanager.God.PC.transform.position) < 2 && Input.GetKeyDown(KeyCode.S))
        {
            floor.enabled = false;
        }
    }
}
