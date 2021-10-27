using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerControl : MonoBehaviour
{
    NavMeshAgent agent;
    public int energy;
    public GameObject[] Cards;
    public GameObject ai;

    // Start is called before the first frame update
    void Start()
    {
        AIControl aiScript = ai.GetComponent<AIControl>();
        if (name == "Mr. Green")
        {
            Cards = aiScript.player1Cards;
        }
        else if (name == "Colonel Mustard")
        {
            Cards = aiScript.player2Cards;
        }
        agent = this.GetComponent<NavMeshAgent>();
    }

    public void myTurn()
    {
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
            if (tempParent.name == "Study" || tempParent.name == "Library" || tempParent.name == "Billiard Room" || tempParent.name == "Conservatory" || tempParent.name == "Ballroom" || tempParent.name == "Hall" || tempParent.name == "Lounge" || tempParent.name == "Dining Room" || tempParent.name == "Kitchen")
            {
                Guess();
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

    public void Guess ()
    {
        
    }
}


//  study: v18
//  Library: q18, o21
//  billiard room: j19, m23
//  conservatory: f20
//  ballroom: f9, h10, h15, f16
//  hall: s13, u15
//  lounge: t7
//  dining room: m8, p7
//  kitchen: g5
