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
    
    public void Start()
    {
        Gamemanager.God.CC = this;
    }
    void Update()
    {
        switch (control)
        {
            case 0:
                #region White face rotation
                if (Gamemanager.God.GM.GameState == Gamemanager.State.cubeControlled)
                {
                    if (Input.GetMouseButton(1))
                    {
                        checkcollision(whiteoverlap);
                        foreach (GameObject obj in rotating)
                        {
                            obj.transform.SetParent(whitecore.transform);
                        }

                        float yRot = Input.GetAxis("Mouse Y") * (-12 * 50) * Time.deltaTime;
                        float xRot = Input.GetAxis("Mouse X") * (-12 * 50) * Time.deltaTime;
                        whitecore.transform.RotateAround(whitecore.transform.position, Vector3.up, yRot);
                        whitecore.transform.RotateAround(whitecore.transform.position, Vector3.up, xRot);
                        //whitecore.transform.Rotate(new Vector3(0, yRot, 0));
                    }
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
                    StartCoroutine(Rotate(redcore, 3, false));
                }
                if (Input.GetKeyDown(KeyCode.D))
                {
                    checkcollision(redoverlap);
                    foreach (GameObject obj in rotating)
                    {
                        obj.transform.SetParent(redcore.transform);
                    }
                    StartCoroutine(Rotate(redcore, 3, true));
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
                    StartCoroutine(Rotate(bluecore, 1, false));
                }
                if (Input.GetKeyDown(KeyCode.D))
                {
                    checkcollision(blueoverlap);
                    foreach (GameObject obj in rotating)
                    {
                        obj.transform.SetParent(bluecore.transform);
                    }
                    StartCoroutine(Rotate(bluecore, 1, true));
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
                    StartCoroutine(Rotate(orangecore, 3, false));
                }
                if (Input.GetKeyDown(KeyCode.D))
                {
                    checkcollision(orangeoverlap);
                    foreach (GameObject obj in rotating)
                    {
                        obj.transform.SetParent(orangecore.transform);
                    }
                    StartCoroutine(Rotate(orangecore, 3, true));
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
                    StartCoroutine(Rotate(yellowcore, 2, false));
                }
                if (Input.GetKeyDown(KeyCode.D))
                {
                    checkcollision(yellowoverlap);
                    foreach (GameObject obj in rotating)
                    {
                        obj.transform.SetParent(yellowcore.transform);
                    }
                    StartCoroutine(Rotate(yellowcore, 2, true));
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
                    StartCoroutine(Rotate(greencore, 1, false));
                }
                if (Input.GetKeyDown(KeyCode.D))
                {
                    checkcollision(greenoverlap);
                    foreach (GameObject obj in rotating)
                    {
                        obj.transform.SetParent(greencore.transform);
                    }
                    StartCoroutine(Rotate(greencore, 1, true));
                }
                break;
                #endregion
        }
    }

    public IEnumerator Rotate(GameObject core, int xyz, bool r)
    {
        switch (xyz)
        {
            case 1:
                if (r)
                {
                    float goalrot = core.transform.rotation.eulerAngles.x + 90;
                    Debug.Log(goalrot);
                    while (core.transform.localRotation.eulerAngles.x<goalrot)
                    {
                        core.transform.Rotate(-5,0,0);
                        yield return new WaitForFixedUpdate();
                    }
                    
                }
                else
                {
                    float goalrot = core.transform.rotation.eulerAngles.x - 90;
                    Debug.Log(goalrot);
                    while (core.transform.localRotation.eulerAngles.x>goalrot)
                    {
                        core.transform.Rotate(5,0,0);
                        yield return new WaitForFixedUpdate();
                    }
                }
                break;
            case 2:
                if (r)
                {
                    float goalrot = core.transform.localRotation.y + 90;
                    Debug.Log(goalrot);
                    while (core.transform.localRotation.eulerAngles.y<goalrot+0.1)
                    {
                        core.transform.Rotate(new Vector3(0,Mathf.LerpAngle(0,90,0.01f),0));
                        yield return new WaitForFixedUpdate();
                    }
                }
                else
                {
                    float goalrot = core.transform.localRotation.y - 90;
                    Debug.Log(goalrot);
                    while (core.transform.localRotation.eulerAngles.y>goalrot-0.01)
                    {
                        core.transform.Rotate(new Vector3(0,Mathf.LerpAngle(0,-90,0.01f),0));
                        yield return new WaitForFixedUpdate();
                    }
                }
                break;
            
            case 3:
                if (r)
                {
                    float goalrot = core.transform.localRotation.z + 90;
                    Debug.Log(goalrot);
                    while (core.transform.localRotation.eulerAngles.z<goalrot+0.01)
                    {
                        core.transform.Rotate(new Vector3(0,0,Mathf.LerpAngle(0,90,0.01f)));
                        yield return new WaitForFixedUpdate();
                    }
                }
                else
                {
                    float goalrot = core.transform.localRotation.z - 90;
                    Debug.Log(goalrot);
                    while (core.transform.localRotation.eulerAngles.z>goalrot-0.01)
                    {
                        core.transform.Rotate(new Vector3(0,0,Mathf.LerpAngle(0,-90,0.01f)));
                        yield return new WaitForFixedUpdate();
                    }
                }
                break;
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
