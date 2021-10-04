using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerControl : MonoBehaviour
{
    public string playerName;
    public NavMeshAgent agent;
    int energy;
    public bool isMyTurn = true;
    bool moving = false;
    
    [HideInInspector] 
    public int horizontal;
    public int vertical;

    // Start is called before the first frame update
    void Start()
    {
        myTurn();
    }

    void myTurn()
    {
        energy = rollDie();
        Debug.Log(energy);
        //Popup text with # of energy
    }
    
    // Update is called once per frame
    void Update()
    {
        if(isMyTurn && !moving)
        {
            if (energy > 0)
            {
                moving = true;
                horizontal = (int)Input.GetAxisRaw("Horizontal");
                vertical = (int)Input.GetAxisRaw("Vertical");
                if ((horizontal != 0) | (vertical != 0))
                {
                    move(horizontal, vertical);
                }
                else
                {
                    moving = false;
                }
            }
        }
    }

    int rollDie () 
    {
        return Random.Range(1, 6);
    }

    void move (float horizontal, float vertical) 
    {
        if (horizontal == -1)
        {
            Debug.Log("Left");
            //move left
            agent.SetDestination(new Vector3(transform.position.x, transform.position.y, transform.position.z + 1));
            energy -= 1;
            Debug.Log(energy);
            moving = false;
        }
        else if (horizontal == 1)
        {
            Debug.Log("Right");
            //move right
            agent.SetDestination(new Vector3(transform.position.x, transform.position.y, transform.position.z - 1));
            energy -= 1;
            Debug.Log(energy);
            moving = false;
        }
        else if (vertical == -1)
        {
            Debug.Log("Down");
            //move down
            agent.SetDestination(new Vector3(transform.position.x - 1, transform.position.y, transform.position.z));
            energy -= 1;
            Debug.Log(energy);
            moving = false;
        }
        else if (vertical == 1)
        {
            Debug.Log("Up");
            //move up
            agent.SetDestination(new Vector3(transform.position.x + 1, transform.position.y, transform.position.z));
            energy -= 1;
            Debug.Log(energy);
            moving = false;
        }
        vertical = 0;
        horizontal = 0;
    }
}