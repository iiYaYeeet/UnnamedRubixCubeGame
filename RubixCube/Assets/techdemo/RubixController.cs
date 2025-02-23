using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubixController : MonoBehaviour
{
    public List<GameObject> everything;
    public List<GameObject> white;
    public List<GameObject> green;
    public List<GameObject> yellow;
    public List<GameObject> orange;
    public List<GameObject> red;
    public List<GameObject> blue;
    public GameObject redcore, bluecore, whitecore, orangecore, yellowcore, greencore,core;
    public int control;
    
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            foreach (GameObject obj in everything)
            {
                obj.transform.SetParent(core.transform);
            }
            control++;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            foreach (GameObject obj in everything)
            {
                obj.transform.SetParent(core.transform);
            }
            control--;
        }

        switch (control)
        {
            case 0:
                foreach (GameObject obj in white)
                {
                    obj.transform.SetParent(core.transform);
                    obj.transform.SetParent(whitecore.transform);
                }
                if (Input.GetKeyDown(KeyCode.A))
                {
                    whitecore.transform.Rotate(new Vector3(0,90,0));
                }
                if (Input.GetKeyDown(KeyCode.D))
                {
                    whitecore.transform.Rotate(new Vector3(0,-90,0));
                }
                break;
            case 1:
                foreach (GameObject obj in red)
                {
                    obj.transform.SetParent(core.transform);
                    obj.transform.SetParent(redcore.transform);
                }
                if (Input.GetKeyDown(KeyCode.A))
                {
                    redcore.transform.Rotate(new Vector3(0,0,90));
                }
                if (Input.GetKeyDown(KeyCode.D))
                {
                    redcore.transform.Rotate(new Vector3(0,0,-90));
                }
                break;
            case 2:
                foreach (GameObject obj in blue)
                {
                    obj.transform.SetParent(core.transform);
                    obj.transform.SetParent(bluecore.transform);
                }
                if (Input.GetKeyDown(KeyCode.A))
                {
                    bluecore.transform.Rotate(new Vector3(90,0,0));
                }
                if (Input.GetKeyDown(KeyCode.D))
                {
                    bluecore.transform.Rotate(new Vector3(-90,0,0));
                }
                break;
            case 3:
                foreach (GameObject obj in orange)
                {
                    obj.transform.SetParent(core.transform);
                    obj.transform.SetParent(orangecore.transform);
                }
                if (Input.GetKeyDown(KeyCode.A))
                {
                    orangecore.transform.Rotate(new Vector3(0,0,90));
                }
                if (Input.GetKeyDown(KeyCode.D))
                {
                    orangecore.transform.Rotate(new Vector3(0,0,-90));
                }
                break;
            case 4:
                foreach (GameObject obj in yellow)
                {
                    obj.transform.SetParent(core.transform);
                    obj.transform.SetParent(yellowcore.transform);
                }
                if (Input.GetKeyDown(KeyCode.A))
                {
                    yellowcore.transform.Rotate(new Vector3(0,90,0));
                }
                if (Input.GetKeyDown(KeyCode.D))
                {
                    yellowcore.transform.Rotate(new Vector3(0,-90,0));
                }
                break;
            case 5:
                foreach (GameObject obj in green)
                {
                    obj.transform.SetParent(core.transform);
                    obj.transform.SetParent(greencore.transform);
                }
                if (Input.GetKeyDown(KeyCode.A))
                {
                    greencore.transform.Rotate(new Vector3(0,0,90));
                }
                if (Input.GetKeyDown(KeyCode.D))
                {
                    greencore.transform.Rotate(new Vector3(0,0,-90));
                }
                break;
        }
    }
}
