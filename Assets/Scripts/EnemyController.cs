using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{


    public GameObject AttackParticles;

    // Path finding
    public Transform goal;
    private NavMeshAgent agent;



    private bool CrashedPlayer;


    private void Start() {


        //goal = FindObjectOfType<BaseController>().transform;
        agent = GetComponent<NavMeshAgent>();
        agent.enabled = true;
        agent.destination = goal.position;

    }

    private void Update() {
        transform.LookAt(goal);
        if (Vector3.Distance(transform.position, goal.position) < 1.1 && !CrashedPlayer) {
            agent.isStopped = true;
            CrashedPlayer = true;
            Attack();
            
        }
     
    }

    private void Attack() {
        GameObject particles = Instantiate(AttackParticles, transform.position + (transform.forward * 0.5f) + new Vector3(0, 0.5f, 0), transform.rotation);
        StartCoroutine(WaitBeforeDestory(particles));
    }

    IEnumerator WaitBeforeDestory(GameObject particles) {
        yield return new WaitForSeconds(1f);
        Destroy(particles);
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
