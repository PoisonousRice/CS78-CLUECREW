using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MouseScript : MonoBehaviour
{
    [HideInInspector]
    public LayerMask layerMask;
    [HideInInspector]
    public Camera cam;
    public GameObject player;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mouseClick();
        }
    }

    void mouseClick()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast(ray, out RaycastHit hitData, Mathf.Infinity, layerMask))
        {
            GameObject hitObject = hitData.transform.gameObject;
            PlayerControl tempScript = player.GetComponent<PlayerControl>();
            tempScript.checkSquare(hitObject);
        }
    }
}