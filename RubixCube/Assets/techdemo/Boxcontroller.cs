using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boxcontroller : MonoBehaviour
{
    public RubixController rc;

    public void OnTriggerStay(Collider other)
    {
        Debug.Log("add");
        rc.rotating.Add(transform.parent.gameObject);
    }

    /*public void OnTriggerExit(Collider other)
    {
        rc.rotating.Remove(transform.parent.gameObject);
    }*/
}
