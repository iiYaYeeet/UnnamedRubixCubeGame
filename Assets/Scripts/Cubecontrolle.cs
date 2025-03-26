using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

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
    public GameObject targ;
    [Header("Ints")]
    [Tooltip("Side to rotate")]public int control;
    [Header("Components")]
    public Animator anim;
    [Header("Floats")]
    public float yRot;
    public float xRot;
    //[Header("Audio")]
    //Audio
    
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
        if (Input.GetMouseButtonUp(1))
        {
            float snappedValue = Mathf.Round(whitecore.transform.localRotation.eulerAngles.y / 90) * 90;
            whitecore.transform.localRotation = Quaternion.Euler(0, snappedValue, 0);
            
            snappedValue = Mathf.Round(redcore.transform.localRotation.eulerAngles.z / 90) * 90;
            redcore.transform.localRotation = Quaternion.Euler(0, 0, snappedValue);
            
            snappedValue = Mathf.Round(bluecore.transform.localRotation.eulerAngles.x / 90) * 90;
            bluecore.transform.localRotation = Quaternion.Euler(snappedValue, 0, 0);
            
            snappedValue = Mathf.Round(orangecore.transform.localRotation.eulerAngles.z / 90) * 90;
            orangecore.transform.localRotation = Quaternion.Euler(0, 0,snappedValue); 
            
            snappedValue = Mathf.Round(yellowcore.transform.localRotation.eulerAngles.y / 90) * 90;
            yellowcore.transform.localRotation = Quaternion.Euler(0, snappedValue, 0);
            
            snappedValue = Mathf.Round(greencore.transform.localRotation.eulerAngles.x / 90) * 90;
            greencore.transform.localRotation = Quaternion.Euler(snappedValue, 0, 0);
            
        }
        switch (control)
        {
            case 0:

                #region White face rotation

                if (Gamemanager.God.GM.GameState == Gamemanager.State.cubeControlled)
                {
                    if (Input.GetMouseButtonDown(1))
                    {
                        float snappedValue = Mathf.Round(whitecore.transform.localRotation.eulerAngles.y / 90) * 90;
                        whitecore.transform.localRotation = Quaternion.Euler(0, snappedValue, 0);
                    }
                    
                    if (Input.GetMouseButton(1))
                    {
                        foreach (GameObject obj in rotating)
                        {
                            obj.transform.SetParent(whitecore.transform);
                        }
                        whitecore.transform.RotateAround(whitecore.transform.position, Vector3.up, yRot);
                        whitecore.transform.RotateAround(whitecore.transform.position, Vector3.up, xRot);
                        float snappedValue = Mathf.Round(whitecore.transform.localRotation.eulerAngles.y / 5) * 5;
                        whitecore.transform.localRotation = Quaternion.Euler(0, snappedValue, 0);
                    }

                    if (Input.GetMouseButtonUp(1))
                    {
                        float snappedValue = Mathf.Round(whitecore.transform.localRotation.eulerAngles.y / 90) * 90;
                        whitecore.transform.localRotation = Quaternion.Euler(0, snappedValue, 0);
                        foreach (GameObject obj in everything)
                        {
                            obj.transform.SetParent(core.transform);
                        }
                    }
                }

                break;

            #endregion

            case 1:

                #region Red face rotation

                if (Gamemanager.God.GM.GameState == Gamemanager.State.cubeControlled)
                {
                    if (Input.GetMouseButtonDown(1))
                    {
                        float snappedValue = Mathf.Round(redcore.transform.localRotation.eulerAngles.z / 90) * 90;
                        redcore.transform.localRotation = Quaternion.Euler(0, 0, snappedValue);
                    }
                    
                    if (Input.GetMouseButton(1))
                    {
                        foreach (GameObject obj in rotating)
                        {
                            obj.transform.SetParent(redcore.transform);
                        }
                        redcore.transform.RotateAround(redcore.transform.position, Vector3.forward, yRot);
                        redcore.transform.RotateAround(redcore.transform.position, Vector3.forward, xRot);
                        float snappedValue = Mathf.Round(redcore.transform.localRotation.eulerAngles.z / 5) * 5;
                        redcore.transform.localRotation = Quaternion.Euler(0, 0, snappedValue);
                    }

                    if (Input.GetMouseButtonUp(1))
                    {
                        float snappedValue = Mathf.Round(redcore.transform.localRotation.eulerAngles.z / 90) * 90;
                        redcore.transform.localRotation = Quaternion.Euler(0, 0, snappedValue);
                        foreach (GameObject obj in everything)
                        {
                            obj.transform.SetParent(core.transform);
                        }
                    }
                }
                break;

            #endregion

            case 2:

                #region Blue face rotation

                if (Gamemanager.God.GM.GameState == Gamemanager.State.cubeControlled)
                {
                    
                    if (Input.GetMouseButtonDown(1))
                    {
                        float snappedValue = Mathf.Round(bluecore.transform.localRotation.eulerAngles.x / 90) * 90;
                        bluecore.transform.localRotation = Quaternion.Euler(snappedValue, 0, 0);
                    }

                    if (Input.GetMouseButton(1))
                    {
                        foreach (GameObject obj in rotating)
                        {
                            obj.transform.SetParent(bluecore.transform);
                        }
                        bluecore.transform.RotateAround(bluecore.transform.position, Vector3.left, yRot);
                        bluecore.transform.RotateAround(bluecore.transform.position, Vector3.left, xRot);
                        float snappedValue = Mathf.Round(bluecore.transform.localRotation.eulerAngles.x / 5) * 5;
                        bluecore.transform.localRotation = Quaternion.Euler(snappedValue, 0, 0);
                    }

                    if (Input.GetMouseButtonUp(1))
                    {
                        float snappedValue = Mathf.Round(bluecore.transform.localRotation.eulerAngles.x / 90) * 90;
                        bluecore.transform.localRotation = Quaternion.Euler(snappedValue, 0, 0);
                        foreach (GameObject obj in everything)
                        {
                            obj.transform.SetParent(core.transform);
                        }
                    }
                }
                break;

            #endregion

            case 3:

                #region Orange face rotation

                if (Gamemanager.God.GM.GameState == Gamemanager.State.cubeControlled)
                {
                    if (Input.GetMouseButtonDown(1))
                    {
                        float snappedValue = Mathf.Round(orangecore.transform.localRotation.eulerAngles.z / 90) * 90;
                        orangecore.transform.localRotation = Quaternion.Euler(0, 0,snappedValue); 
                    }
                    
                    if (Input.GetMouseButton(1))
                    {
                        foreach (GameObject obj in rotating)
                        {
                            obj.transform.SetParent(orangecore.transform);
                        }
                        orangecore.transform.RotateAround(orangecore.transform.position, Vector3.back, yRot);
                        orangecore.transform.RotateAround(orangecore.transform.position, Vector3.back, xRot);
                        float snappedValue = Mathf.Round(orangecore.transform.localRotation.eulerAngles.z / 5) * 5;
                        orangecore.transform.localRotation = Quaternion.Euler(0, 0,snappedValue); 
                    }

                    if (Input.GetMouseButtonUp(1))
                    {
                        float snappedValue = Mathf.Round(orangecore.transform.localRotation.eulerAngles.z / 90) * 90;
                        orangecore.transform.localRotation = Quaternion.Euler(0, 0,snappedValue);
                        foreach (GameObject obj in everything)
                        {
                            obj.transform.SetParent(core.transform);
                        } 
                    }
                }
                break;

            #endregion

            case 4:

                #region Yellow face rotation

                if (Gamemanager.God.GM.GameState == Gamemanager.State.cubeControlled)
                {
                    if (Input.GetMouseButtonDown(1))
                    {
                        float snappedValue = Mathf.Round(yellowcore.transform.localRotation.eulerAngles.y / 90) * 90;
                        yellowcore.transform.localRotation = Quaternion.Euler(0, snappedValue, 0);
                    }
                    
                    if (Input.GetMouseButton(1))
                    {
                        foreach (GameObject obj in rotating)
                        {
                            obj.transform.SetParent(yellowcore.transform);
                        }
                        yellowcore.transform.RotateAround(yellowcore.transform.position, Vector3.down, yRot);
                        yellowcore.transform.RotateAround(yellowcore.transform.position, Vector3.down, xRot);
                        float snappedValue = Mathf.Round(yellowcore.transform.localRotation.eulerAngles.y /5) * 5;
                        yellowcore.transform.localRotation = Quaternion.Euler(0, snappedValue, 0);
                    }

                    if (Input.GetMouseButtonUp(1))
                    {
                        float snappedValue = Mathf.Round(yellowcore.transform.localRotation.eulerAngles.y / 90) * 90;
                        yellowcore.transform.localRotation = Quaternion.Euler(0, snappedValue, 0);
                        foreach (GameObject obj in everything)
                        {
                            obj.transform.SetParent(core.transform);
                        }
                    }
                }

                break;

            #endregion

            case 5:

                #region Green face rotation

                if (Gamemanager.God.GM.GameState == Gamemanager.State.cubeControlled)
                {
                    if (Input.GetMouseButtonDown(1))
                    {
                        float snappedValue = Mathf.Round(greencore.transform.localRotation.eulerAngles.x / 90) * 90;
                        greencore.transform.localRotation = Quaternion.Euler(snappedValue, 0, 0);
                    }
                    
                    if (Input.GetMouseButton(1))
                    {
                        foreach (GameObject obj in rotating)
                        {
                            obj.transform.SetParent(greencore.transform);
                        }
                        greencore.transform.RotateAround(greencore.transform.position, Vector3.right, yRot);
                        greencore.transform.RotateAround(greencore.transform.position, Vector3.right, xRot);
                        float snappedValue = Mathf.Round(greencore.transform.localRotation.eulerAngles.x / 5) * 5;
                        greencore.transform.localRotation = Quaternion.Euler(snappedValue, 0, 0);
                    }
                    
                    if (Input.GetMouseButtonUp(1))
                    {
                        float snappedValue = Mathf.Round(greencore.transform.localRotation.eulerAngles.x / 90) * 90;
                        greencore.transform.localRotation = Quaternion.Euler(snappedValue, 0, 0);
                        foreach (GameObject obj in everything)
                        {
                            obj.transform.SetParent(core.transform);
                        }
                    }
                }
                break;

            #endregion

        }
    }

    public IEnumerator rand()
    {
        foreach (GameObject obj in everything)
        {
            obj.transform.SetParent(core.transform);
        }
        int loops = Random.Range(10, 30);
        for (int i = 0; i < loops; i++)
        {
            int random = Random.Range(0, 6);
            if (random == 0)
            {
                checkcollision(whiteoverlap);
                foreach (GameObject obj in rotating)
                {
                    obj.transform.SetParent(whitecore.transform);
                }
                if (Random.Range(0, 1) == 0)
                {
                    whitecore.transform.Rotate(0,90,0);
                    rotating.Clear();
                    foreach (GameObject obj in everything)
                    {
                        obj.transform.SetParent(core.transform);
                    }
                }
                else
                {
                    whitecore.transform.Rotate(0,-90,0);
                    rotating.Clear();
                    foreach (GameObject obj in everything)
                    {
                        obj.transform.SetParent(core.transform);
                    }
                }
                yield return new WaitForFixedUpdate();
            }
            if (random == 1)
            {
                checkcollision(redoverlap);
                foreach (GameObject obj in rotating)
                {
                    obj.transform.SetParent(redcore.transform);
                }
                if (Random.Range(0, 1) == 0)
                {
                    redcore.transform.Rotate(0,0,90);
                    rotating.Clear();
                    foreach (GameObject obj in everything)
                    {
                        obj.transform.SetParent(core.transform);
                    }
                }
                else
                {
                    redcore.transform.Rotate(0,0,-90);
                    rotating.Clear();
                    foreach (GameObject obj in everything)
                    {
                        obj.transform.SetParent(core.transform);
                    }
                }
                yield return new WaitForFixedUpdate();
            }
            if (random == 2)
            {
                checkcollision(yellowoverlap);
                foreach (GameObject obj in rotating)
                {
                    obj.transform.SetParent(yellowcore.transform);
                }
                if (Random.Range(0, 1) == 0)
                {
                    yellowcore.transform.Rotate(0,90,0);
                    rotating.Clear();
                    foreach (GameObject obj in everything)
                    {
                        obj.transform.SetParent(core.transform);
                    }
                }
                else
                {
                    yellowcore.transform.Rotate(0,-90,0);
                    rotating.Clear();
                    foreach (GameObject obj in everything)
                    {
                        obj.transform.SetParent(core.transform);
                    }
                }
                yield return new WaitForFixedUpdate();
            }
            if (random == 3)
            {
                checkcollision(greenoverlap);
                foreach (GameObject obj in rotating)
                {
                    obj.transform.SetParent(greencore.transform);
                }
                if (Random.Range(0, 1) == 0)
                {
                    greencore.transform.Rotate(90,0,0);
                    rotating.Clear();
                    foreach (GameObject obj in everything)
                    {
                        obj.transform.SetParent(core.transform);
                    }
                }
                else
                {
                    greencore.transform.Rotate(-90,0,0);
                    rotating.Clear();
                    foreach (GameObject obj in everything)
                    {
                        obj.transform.SetParent(core.transform);
                    }
                }
                yield return new WaitForFixedUpdate();
            }
            if (random == 4)
            {
                checkcollision(blueoverlap);
                foreach (GameObject obj in rotating)
                {
                    obj.transform.SetParent(bluecore.transform);
                }
                if (Random.Range(0, 1) == 0)
                {
                    bluecore.transform.Rotate(90,0,0);
                    rotating.Clear();
                    foreach (GameObject obj in everything)
                    {
                        obj.transform.SetParent(core.transform);
                    }
                }
                else
                {
                    bluecore.transform.Rotate(-90,0,0);
                    rotating.Clear();
                    foreach (GameObject obj in everything)
                    {
                        obj.transform.SetParent(core.transform);
                    }
                }
                yield return new WaitForFixedUpdate();
            }
            if (random == 5)
            {
                checkcollision(orangeoverlap);
                foreach (GameObject obj in rotating)
                {
                    obj.transform.SetParent(orangecore.transform);
                }
                if (Random.Range(0, 1) == 0)
                {
                    orangecore.transform.Rotate(0,0,90);
                    rotating.Clear();
                    foreach (GameObject obj in everything)
                    {
                        obj.transform.SetParent(core.transform);
                    }
                }
                else
                {
                    orangecore.transform.Rotate(0,0,-90);
                    rotating.Clear();
                    foreach (GameObject obj in everything)
                    {
                        obj.transform.SetParent(core.transform);
                    }
                }
                yield return new WaitForFixedUpdate();
            }
            yield return null;
        }
        foreach (GameObject obj in everything)
        {
            obj.transform.SetParent(core.transform);
        }
    }
    public void checkcollision(GameObject cr)
    {
        rotating.Clear();
        foreach (GameObject obj in everything)
        {
            obj.transform.SetParent(core.transform);
        }
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
