using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateController : MonoBehaviour
{

    public int countToFall = 0;
    public bool registered;
    public int destroyCount = 4;

    private Renderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();

    }

    private void OnTriggerEnter(Collider other) {
        if ((other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Attack")) && !registered) {
            print("player");
            PLayeMovement.PlateWasHit += CountHits;
            registered = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (countToFall == destroyCount) {
            StartCoroutine(WaitBeforeDestory());
        }
            
    }


    IEnumerator WaitBeforeDestory() {
        yield return new WaitForSeconds(0.7f);
        PLayeMovement.PlateWasHit -= CountHits;
        Destroy(gameObject);
    }

    void CountHits() {
        
        Color color = renderer.material.color;
        color.a -= 0.25f;
        renderer.material.color = color;

        countToFall++;
    }
}
