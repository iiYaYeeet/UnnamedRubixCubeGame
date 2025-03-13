using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubecontrolle : MonoBehaviour
{
    //[Header("Components")]
    //components
    [Header("Objects")]
    //objects
    [Tooltip("Central Rubix cube core")] public GameObject core;
    [Tooltip("Outer face cores")]public GameObject redcore, bluecore, whitecore, orangecore, yellowcore, greencore;
    [Tooltip("Overlap box for rotation")]public GameObject redoverlap, blueoverlap, whiteoverlap, orangeoverlap, yellowoverlap, greenoverlap;
    [Header("Lists")]
    [Tooltip("Currently rotating objects")]public List<GameObject> rotating;
    public List<GameObject> everything;
    [Header("Ints")]
    [Tooltip("Side to rotate")]public int control;
    [Header("Components")]
    public Animator anim;
    //[Header("Floats")]
    //Floats
    //[Header("Audio")]
    //Audio

    public float yRot;
    public float xRot;
    
    public void Start()
    {
        Gamemanager.God.CC = this;
    }
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            if (Input.mousePosition.x < Screen.width / 2)
            {
                
                yRot = -Input.GetAxis("Mouse Y") * (-12 * 50) * Time.deltaTime;
            }
            else
            {
                yRot = Input.GetAxis("Mouse Y") * (-12 * 50) * Time.deltaTime;
            }

            if (Input.mousePosition.y < Screen.height / 2)
            {
                xRot = Input.GetAxis("Mouse X") * (-12 * 50) * Time.deltaTime;
            }
            else
            {
                xRot = -Input.GetAxis("Mouse X") * (-12 * 50) * Time.deltaTime;
            }
        }

        switch (control)
        {
            case 0:

                #region White face rotation

                if (Gamemanager.God.GM.GameState == Gamemanager.State.cubeControlled)
                {
                    foreach (GameObject obj in rotating)
                    {
                        obj.transform.SetParent(whitecore.transform);
                    }

                    if (Input.GetMouseButton(1))
                    {
                        whitecore.transform.RotateAround(whitecore.transform.position, Vector3.up, yRot);
                        whitecore.transform.RotateAround(whitecore.transform.position, Vector3.up, xRot);
                    }

                    if (Input.GetMouseButtonUp(1))
                    {
                        float snappedValue = Mathf.Round(whitecore.transform.localRotation.eulerAngles.y / 90) * 90;
                        whitecore.transform.localRotation = Quaternion.Euler(0, snappedValue, 0);
                    }
                }

                break;

            #endregion

            case 1:

                #region Red face rotation

                if (Gamemanager.God.GM.GameState == Gamemanager.State.cubeControlled)
                {
                    foreach (GameObject obj in rotating)
                    {
                        obj.transform.SetParent(redcore.transform);
                    }

                    if (Input.GetMouseButton(1))
                    {
                        redcore.transform.RotateAround(redcore.transform.position, Vector3.forward, yRot);
                        redcore.transform.RotateAround(redcore.transform.position, Vector3.forward, xRot);
                    }

                    if (Input.GetMouseButtonUp(1))
                    {
                        float snappedValue = Mathf.Round(redcore.transform.localRotation.eulerAngles.z / 90) * 90;
                        redcore.transform.localRotation = Quaternion.Euler(0, 0, snappedValue);
                    }
                }
                break;

            #endregion

            case 2:

                #region Blue face rotation

                if (Gamemanager.God.GM.GameState == Gamemanager.State.cubeControlled)
                {
                    foreach (GameObject obj in rotating)
                    {
                        obj.transform.SetParent(bluecore.transform);
                    }

                    if (Input.GetMouseButton(1))
                    {
                        bluecore.transform.RotateAround(bluecore.transform.position, Vector3.left, yRot);
                        bluecore.transform.RotateAround(bluecore.transform.position, Vector3.left, xRot);
                    }

                    if (Input.GetMouseButtonUp(1))
                    {
                        float snappedValue = Mathf.Round(bluecore.transform.localRotation.eulerAngles.x / 90) * 90;
                        bluecore.transform.localRotation = Quaternion.Euler(snappedValue, 0, 0);
                    }
                }
                break;

            #endregion

            case 3:

                #region Orange face rotation

                if (Gamemanager.God.GM.GameState == Gamemanager.State.cubeControlled)
                {
                    foreach (GameObject obj in rotating)
                    {
                        obj.transform.SetParent(orangecore.transform);
                    }

                    if (Input.GetMouseButton(1))
                    {
                        orangecore.transform.RotateAround(orangecore.transform.position, Vector3.back, yRot);
                        orangecore.transform.RotateAround(orangecore.transform.position, Vector3.back, xRot);
                    }

                    if (Input.GetMouseButtonUp(1))
                    {
                        float snappedValue = Mathf.Round(orangecore.transform.localRotation.eulerAngles.z / 90) * 90;
                        orangecore.transform.localRotation = Quaternion.Euler(0, 0,snappedValue); 
                    }
                }
                break;

            #endregion

            case 4:

                #region Yellow face rotation

                if (Gamemanager.God.GM.GameState == Gamemanager.State.cubeControlled)
                {
                    foreach (GameObject obj in rotating)
                    {
                        obj.transform.SetParent(yellowcore.transform);
                    }

                    if (Input.GetMouseButton(1))
                    {
                        yellowcore.transform.RotateAround(yellowcore.transform.position, Vector3.down, yRot);
                        yellowcore.transform.RotateAround(yellowcore.transform.position, Vector3.down, xRot);
                    }

                    if (Input.GetMouseButtonUp(1))
                    {
                        float snappedValue = Mathf.Round(yellowcore.transform.localRotation.eulerAngles.y / 90) * 90;
                        yellowcore.transform.localRotation = Quaternion.Euler(0, snappedValue, 0);
                    }
                }

                break;

            #endregion

            case 5:

                #region Green face rotation

                if (Gamemanager.God.GM.GameState == Gamemanager.State.cubeControlled)
                {
                    foreach (GameObject obj in rotating)
                    {
                        obj.transform.SetParent(greencore.transform);
                    }
                    if (Input.GetMouseButton(1))
                    {
                        greencore.transform.RotateAround(greencore.transform.position, Vector3.right, yRot);
                        greencore.transform.RotateAround(greencore.transform.position, Vector3.right, xRot);
                    }
                    if (Input.GetMouseButtonUp(1))
                    {
                        float snappedValue = Mathf.Round(greencore.transform.localRotation.eulerAngles.x / 90) * 90;
                        greencore.transform.localRotation = Quaternion.Euler(snappedValue, 0, 0);
                    }
                }
                break;

            #endregion
        }
    }

    public void checkcollision(GameObject cr)
    {
        Collider[] cols = Physics.OverlapBox(cr.transform.position, cr.transform.localScale, cr.transform.rotation);
        foreach (var col in cols)
        {
            if (col.gameObject.CompareTag("Rotatable"))
            {
                rotating.Add(col.gameObject);
            }
        }
    }
}
