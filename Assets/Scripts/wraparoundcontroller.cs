using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wraparoundcontroller : MonoBehaviour
{
    public Transform playertarget;
    public Transform colcheck;
    
    public enum Direction
    {
        Up,
        Down,
        Left,
        Right,
    }
    [SerializeField] public Direction Rotationdir = Direction.Up;

    void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(colcheck.transform.position, colcheck.transform.localScale);
        Gizmos.DrawWireCube(playertarget.transform.position, playertarget.transform.localScale);
    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            var vector3 = Gamemanager.God.PC.transform.position;
            Collider[] cols = Physics.OverlapBox(colcheck.transform.position, colcheck.transform.localScale, colcheck.transform.rotation);
            Debug.Log(cols);
            if (cols.Length < 2)
            {
                if (Rotationdir == Direction.Up)
                {
                    Debug.Log("uprot");
                    Gamemanager.God.CC.transform.Rotate(0, 0, -90,Space.World);
                    Gamemanager.God.PC.RB.AddForce(transform.up * 15, ForceMode.Impulse);
                    vector3.y = playertarget.position.y;
                }

                if (Rotationdir == Direction.Down)
                {
                    Debug.Log("downrot");
                    Gamemanager.God.CC.transform.Rotate(0, 0, 90,Space.World);
                    vector3.y = playertarget.position.y;
                }

                if (Rotationdir == Direction.Left)
                {
                    Debug.Log("leftrot");
                    Gamemanager.God.CC.transform.Rotate(0, -90, 0,Space.World);
                    vector3.z = playertarget.position.z;
                }

                if (Rotationdir == Direction.Right)
                {
                    Debug.Log("rightrot");
                    Gamemanager.God.CC.transform.Rotate(0, 90, 0,Space.World);
                    vector3.z = playertarget.position.z;
                }
                
                Gamemanager.God.PC.transform.position = vector3;
            }
        }
    }
}
