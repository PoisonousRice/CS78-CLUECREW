using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIControl : MonoBehaviour
{
    [HideInInspector]
    public GameObject[] players = new GameObject[6]; // Mr. Green, Colonel Mustard, Ms. Peacock, Professor Plum, Scarlett, Ms. White
    [HideInInspector]
    public MouseScript mouse;
    GameObject activePlayer;
    PlayerControl apScript;

    [HideInInspector]
    public int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        activePlayer = players[count];
        mouse.player = activePlayer;
        apScript = activePlayer.GetComponent<PlayerControl>();
        apScript.myTurn();
    }

    // Update is called once per frame
    void Update()
    {
        if(apScript.energy == 0)
        {
            if (count == 5){count = 0;}
            else {count += 1;}
            activePlayer = players[count];
            mouse.player = activePlayer;
            apScript = activePlayer.GetComponent<PlayerControl>();
            apScript.myTurn();
        }
    }
}
