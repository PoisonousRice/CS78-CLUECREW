using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIControl : MonoBehaviour
{
    public GameObject[] players = new GameObject[6]; // Mr. Green, Colonel Mustard, Ms. Peacock, Professor Plum, Scarlett, Ms. White
    public MouseScript mouse;
    GameObject activePlayer;
    PlayerControl apScript;
    public int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        activePlayer = players[0];
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