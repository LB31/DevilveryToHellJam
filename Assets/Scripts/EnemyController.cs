using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{




    // Path finding
    public Transform goal;
    private NavMeshAgent agent;



    private bool CrashedPlayer;
    private float t;

    private void Start() {


        //goal = FindObjectOfType<BaseController>().transform;
        agent = GetComponent<NavMeshAgent>();
        agent.enabled = true;
        agent.destination = goal.position;

    }

    private void Update() {


    }











    // Tracks, if angel have attacked player to stop him for some seconds
    private void OnTriggerEnter(Collider other) {
        // If the angel crashes the player without being seen
        if (other.gameObject.CompareTag("Player")) {

            CrashedPlayer = true;
            agent.enabled = false;

        }
    }


}
