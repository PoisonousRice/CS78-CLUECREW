using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerControl : MonoBehaviour
{
    public string playerName;
    public NavMeshAgent agent;
    int energy = 0;
    bool myTurn;

    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (myTurn) {
            energy = rollDie();
            //Popup text with # of energy
        }
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
    }

    int rollDie() {
        int temp = Random.Range(1, 6) + Random.Range(1, 6);
        return temp;
    }
}
