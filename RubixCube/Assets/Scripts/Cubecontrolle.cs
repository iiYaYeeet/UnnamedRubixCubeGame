using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubecontrolle : MonoBehaviour
{
    public List<GameObject> rotating;
    public List<GameObject> everything;
    public GameObject redcore, bluecore, whitecore, orangecore, yellowcore, greencore,x,y,z,core;
    public GameObject redoverlap, blueoverlap, whiteoverlap, orangeoverlap, yellowoverlap, greenoverlap;
    public int control;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            foreach (GameObject obj in everything)
            {
                obj.transform.SetParent(core.transform);
            }
            rotating.Clear();
            control++;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            foreach (GameObject obj in everything)
            {
                obj.transform.SetParent(core.transform);
            }
            rotating.Clear();
            control--;
        }

        switch (control)
        {
            case 0:
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
            case 1:
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
            case 2:
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
            case 3:
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
            case 4:
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
            case 5:
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
        }
    }

    public void checkcollision(GameObject cr)
    {
        Collider[] cols = Physics.OverlapBox(cr.transform.position, cr.transform.localScale, cr.transform.rotation);
        foreach (var col in cols)
        {
            rotating.Add(col.gameObject);
        }
    }
}
