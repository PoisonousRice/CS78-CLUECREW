using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuessingSheet : MonoBehaviour
{
    public LayerMask layerMask;
    public Camera cam;
    public Material Material0;
    public Material Material1;
    public aiControl aiScript;
    public GameObject[] guesses = new GameObject[3];
    public int count = 0;

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
            
            if(hitObject.transform.parent.gameObject.name == "characters")
            {
                for (int i = 0; i < hitObject.transform.parent.childCount; i++)
                {
                    hitObject.transform.parent.GetChild(i).gameObject.GetComponent<MeshRenderer>().material = Material0;
                }
                hitObject.GetComponent<MeshRenderer>().material = Material1;
                guesses[0] = hitObject;
            }
            else if (hitObject.transform.parent.gameObject.name == "weapons")
            {
                for (int i = 0; i < hitObject.transform.parent.childCount; i++)
                {
                    hitObject.transform.parent.GetChild(i).gameObject.GetComponent<MeshRenderer>().material = Material0;
                }
                hitObject.GetComponent<MeshRenderer>().material = Material1;
                guesses[1] = hitObject;
            }
            else if (hitObject.transform.parent.gameObject.name == "rooms")
            {
                for (int i = 0; i < hitObject.transform.parent.childCount; i++)
                {
                    hitObject.transform.parent.GetChild(i).gameObject.GetComponent<MeshRenderer>().material = Material0;
                }
                hitObject.GetComponent<MeshRenderer>().material = Material1;
                guesses[2] = hitObject;
            }

            if(hitObject.name == "guessConfirm")
            {
                for(int i = 0; i < 3; i++)
                {
                    Debug.Log(guesses[i]);
                }
                aiScript.checkGuess(guesses);
            }
        }
    }
}
