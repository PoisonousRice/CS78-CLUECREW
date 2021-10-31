using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackerSheet : MonoBehaviour
{

    public LayerMask layerMask;
    public Camera cam;
    public Material Material1, Material0;

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
            hitObject.GetComponent<MeshRenderer>().material = Material1;
            
        }
    }

}
