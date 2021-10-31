using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerControl : MonoBehaviour
{
    NavMeshAgent agent;
    public int energy;
    public GameObject[] Cards;
    public Vector3[] cardLocs;
    public GameObject guessSheet;
    public GameObject guessSheetRooms;
    public Material mat;

    void Awake()
    {
        cardLocs = new Vector3[9]{new Vector3(14.5f, 0f, -15.5f), new Vector3(11f, 0f, -15.5f), new Vector3(7.5f, 0f, -15.5f), new Vector3(4f, 0f, -15.5f), new Vector3(0.5f, 0f, -15.5f), new Vector3(-3f, 0f, -15.5f), new Vector3(-6.5f, 0f, -15.5f), new Vector3(-10f, 0f, -15.5f), new Vector3(-13.5f, 0f, -15.5f)};
    }
    // Start is called before the first frame update
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
    }

    public void myTurn()
    {
        if(this.name == "Mr. Green")
        {
            for (int i = 0; i < Cards.Length; i++)
            {
                Cards[i].transform.position = cardLocs[i];
                Cards[i].SetActive(true);
            }
        }
        else
        {
            for (int i = 0; i < Cards.Length; i++)
            {
                Cards[i].transform.position = cardLocs[i];
                Cards[i].SetActive(true);
            }
        }
        energy = rollDie();
        Debug.Log("Dice Roll: " + energy);
        //Popup text with # of energy
    }
    
    public void checkSquare(GameObject square)
    {
        int dist = (int)Mathf.Abs(transform.position.x - square.transform.position.x) + (int)Mathf.Abs(transform.position.z - square.transform.position.z);

        if (dist <= energy)
        {
            agent.SetDestination(square.transform.position);
            GameObject tempParent = square.transform.parent.gameObject;
            if (tempParent.name == "Study")
            {
                Guess("Study check");
            }
            else if (tempParent.name == "Library")
            {
                Guess("Library check");
            }
            else if (tempParent.name == "Billiard Room")
            {
                Guess("Billiard room check");
            }
            else if (tempParent.name == "Conservatory")
            {
                Guess("Conservatory check");
            } 
            else if (tempParent.name == "Ballroom")
            {
                Guess("Ballroom check");
            } 
            else if (tempParent.name == "Hall")
            {
                Guess("Hall check");
            } 
            else if (tempParent.name == "Lounge")
            {
                Guess("Lounge check");
            } 
            else if (tempParent.name == "Dining Room")
            {
                Guess("Dining room check");
            } 
            else if (tempParent.name == "Kitchen")
            {
                Guess("Kitchen check");
            }
            else 
            {
                energy -= dist;
            }
            Debug.Log("Remaining Squares: " + energy);
        }
    }

    int rollDie () 
    {
        return Random.Range(1, 6);
    }

    public void Guess (string n)
    {
        guessSheet.SetActive(true);
        guessSheetRooms.transform.Find(n).gameObject.GetComponent<MeshRenderer>().material = mat;
        guessSheet.GetComponent<GuessingSheet>().guesses[2] = guessSheetRooms.transform.Find(n).gameObject;
    }
}