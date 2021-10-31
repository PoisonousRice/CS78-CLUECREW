using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aiControl : MonoBehaviour
{
    public GameObject[] players = new GameObject[2];
    public List<GameObject> deck = new List<GameObject>();
    public GameObject[] player1Cards = new GameObject[9];
    public GameObject[] player2Cards = new GameObject[9];
    public MouseScript mouse;
    GameObject activePlayer;
    PlayerControl apScript;
    public int count = 0;
    public GameObject[] answers = new GameObject[3];
    public GameObject peopleCards, weaponCards, roomCards, p1Tracker, p2Tracker, guessTracker;
    bool setup = true;

    // Start is called before the first frame update
    void Start()
    {
        answers[0] = peopleCards.transform.GetChild((int)Random.Range(0,5)).gameObject;
        answers[1] = weaponCards.transform.GetChild((int)Random.Range(0,5)).gameObject;
        answers[2] = roomCards.transform.GetChild((int)Random.Range(0,8)).gameObject;

        for(int a = 0; a < 3; a++)
        {
            answers[a].SetActive(false);
        }

        for (int e = 0; e < deck.Count; e++)
        {
            if(!(deck[e].activeSelf))
            {
                deck.RemoveAt(e);
            }
        }

        for (int f = 0; f < 18; f++)
        {
            if(f < 9)
            {
                player1Cards[f] = deck[f];
            }
            else
            {
                player2Cards[f - 9] = deck[f];
            }
        }
        activePlayer = players[0];
        mouse.player = activePlayer;
        apScript = activePlayer.GetComponent<PlayerControl>();
        apScript.Cards = player1Cards;
        players[1].GetComponent<PlayerControl>().Cards = player2Cards;

        for(int i = 0; i < 9; i++)
        {
            players[1].GetComponent<PlayerControl>().Cards[i].SetActive(false);
        }
        
        setup = false;
        apScript.myTurn();
    }

    // Update is called once per frame
    void Update()
    {
        if (!setup)
        {
            if(apScript.energy == 0)
            {
                if (activePlayer.name == "Mr. Green"){count = 1;}
                else {count = 0;}
                for(int i = 0; i < 9; i++)
                {
                    apScript.Cards[i].SetActive(false);
                }
                activePlayer = players[count];
                mouse.player = activePlayer;
                apScript = activePlayer.GetComponent<PlayerControl>();
                if(count == 1)
                {
                    p1Tracker.SetActive(false);
                    p2Tracker.SetActive(true);
                }
                else
                {
                    p2Tracker.SetActive(false);
                    p1Tracker.SetActive(true);
                }
                apScript.myTurn();
            }
        }
    }

    public void checkGuess(GameObject[] guesses)
    {
        string[] answerTags = new string[] {answers[0].tag, answers[1].tag, answers[2].tag};
        string[] guessTags = new string[] {guesses[0].tag, guesses[1].tag, guesses[2].tag};
        bool correct = false;
        for (int i = 0; i < 3; i++)
        {
            if (guessTags[i] == answerTags[i])
            {
                correct = true;
            }
            else
            {
                correct = false;
                break;
            }
        }
        if(correct)
        {
            Debug.Log("win");
            guessTracker.GetComponent<GuessingSheet>().resetSheet();
        }
        else if (guessTags[0] == answerTags[0])
        {
            Debug.Log("correct character");
            activePlayer.GetComponent<PlayerControl>().energy = 0;
            guessTracker.GetComponent<GuessingSheet>().resetSheet();
        }
        else if (guessTags[1] == answerTags[1])
        {
            Debug.Log("correct weapon");
            activePlayer.GetComponent<PlayerControl>().energy = 0;
        }
        else if (guessTags[2] == answerTags[2])
        {
            Debug.Log("correct room");
            activePlayer.GetComponent<PlayerControl>().energy = 0;
        }
    }
}