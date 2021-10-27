using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIControl : MonoBehaviour
{
    public GameObject[] players = new GameObject[2]; // Mr. Green, Colonel Mustard, Ms. Peacock, Professor Plum, Scarlett, Ms. White
    public GameObject[] deck = new GameObject[21];
    public GameObject[] player1Cards = new GameObject[11];
    public GameObject[] player2Cards = new GameObject[10];
    public MouseScript mouse;
    GameObject activePlayer;
    PlayerControl apScript;
    public int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 21; i++)
        {
            if (i < 11)
            {
                player1Cards[i] = deck[i];
            }
            else
            {
                player2Cards[i-11] = deck[i];
            }
        }
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
            if (activePlayer.name == "Mr. Green"){count = 1;}
            else {count = 0;}
            activePlayer = players[count];
            mouse.player = activePlayer;
            apScript = activePlayer.GetComponent<PlayerControl>();
            apScript.myTurn();
        }
    }
}