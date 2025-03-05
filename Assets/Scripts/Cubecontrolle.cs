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
    //[Header("Components")]
    //components
    //[Header("Floats")]
    //Floats
    //[Header("Audio")]
    //Audio
    void Update()
    {
        #region Select face input
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            /*foreach (GameObject obj in everything)
            {
                obj.transform.SetParent(core.transform);
            }*/
            rotating.Clear();
            control++;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            /*foreach (GameObject obj in everything)
            {
                obj.transform.SetParent(core.transform);
            }*/
            rotating.Clear();
            control--;
        }
        #endregion
        switch (control)
        {
            case 0:
                #region White face rotation
                if (Input.GetKeyDown(KeyCode.A))
                {
                    checkcollision(whiteoverlap);
                    foreach (GameObject obj in rotating)
                    {
                        obj.transform.SetParent(whitecore.transform);
                    }
                    whitecore.transform.Rotate(new Vector3(0,90,0));
                    rotating.Clear();
                }
                if (Input.GetKeyDown(KeyCode.D))
                {
                    checkcollision(whiteoverlap);
                    foreach (GameObject obj in rotating)
                    {
                        obj.transform.SetParent(whitecore.transform);
                    }
                    whitecore.transform.Rotate(new Vector3(0,-90,0));
                    rotating.Clear();
                }
                break;
                #endregion
            case 1:
                #region Red face rotation
                if (Input.GetKeyDown(KeyCode.A))
                {
                    checkcollision(redoverlap);
                    foreach (GameObject obj in rotating)
                    {
                        obj.transform.SetParent(redcore.transform);
                    }
                    redcore.transform.Rotate(new Vector3(0,0,90));
                }
                if (Input.GetKeyDown(KeyCode.D))
                {
                    checkcollision(redoverlap);
                    foreach (GameObject obj in rotating)
                    {
                        obj.transform.SetParent(redcore.transform);
                    }
                    redcore.transform.Rotate(new Vector3(0,0,-90));
                }
                break;
                #endregion
            case 2:
                #region Blue face rotation
                if (Input.GetKeyDown(KeyCode.A))
                {
                    checkcollision(blueoverlap);
                    foreach (GameObject obj in rotating)
                    {
                        obj.transform.SetParent(bluecore.transform);
                    }
                    bluecore.transform.Rotate(new Vector3(90,0,0));
                }
                if (Input.GetKeyDown(KeyCode.D))
                {
                    checkcollision(blueoverlap);
                    foreach (GameObject obj in rotating)
                    {
                        obj.transform.SetParent(bluecore.transform);
                    }
                    bluecore.transform.Rotate(new Vector3(-90,0,0));
                }
                break;
                #endregion
            case 3:
                #region Orange face rotation
                if (Input.GetKeyDown(KeyCode.A))
                {
                    checkcollision(orangeoverlap);
                    foreach (GameObject obj in rotating)
                    {
                        obj.transform.SetParent(orangecore.transform);
                    }
                    orangecore.transform.Rotate(new Vector3(0,0,90));
                }
                if (Input.GetKeyDown(KeyCode.D))
                {
                    checkcollision(orangeoverlap);
                    foreach (GameObject obj in rotating)
                    {
                        obj.transform.SetParent(orangecore.transform);
                    }
                    orangecore.transform.Rotate(new Vector3(0,0,-90));
                }
                break;
                #endregion
            case 4:
                #region Yellow face rotation
                if (Input.GetKeyDown(KeyCode.A))
                {
                    checkcollision(yellowoverlap);
                    foreach (GameObject obj in rotating)
                    {
                        obj.transform.SetParent(yellowcore.transform);
                    }
                    yellowcore.transform.Rotate(new Vector3(0,90,0));
                }
                if (Input.GetKeyDown(KeyCode.D))
                {
                    checkcollision(yellowoverlap);
                    foreach (GameObject obj in rotating)
                    {
                        obj.transform.SetParent(yellowcore.transform);
                    }
                    yellowcore.transform.Rotate(new Vector3(0,-90,0));
                }
                break;
                #endregion
            case 5:
                #region Green face rotation
                if (Input.GetKeyDown(KeyCode.A))
                {
                    checkcollision(greenoverlap);
                    foreach (GameObject obj in rotating)
                    {
                        obj.transform.SetParent(greencore.transform);
                    }
                    greencore.transform.Rotate(new Vector3(90,0,0));
                }
                if (Input.GetKeyDown(KeyCode.D))
                {
                    checkcollision(greenoverlap);
                    foreach (GameObject obj in rotating)
                    {
                        obj.transform.SetParent(greencore.transform);
                    }
                    greencore.transform.Rotate(new Vector3(-90,0,0));
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
