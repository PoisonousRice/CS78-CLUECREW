using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerControl : MonoBehaviour
{
    NavMeshAgent agent;
    public int energy;

    // Start is called before the first frame update
    void Start()
    {
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
            energy -= dist;
            Debug.Log("Remaining Squares: " + energy);
        }
    }

    int rollDie () 
    {
        return Random.Range(1, 6);
    }
}