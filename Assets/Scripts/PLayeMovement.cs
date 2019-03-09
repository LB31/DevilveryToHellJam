using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayeMovement : MonoBehaviour
{
    public float moveSpeed;

    public bool moving;

    public Vector3 posToMove = new Vector3();

    // Start is called before the first frame update
    void Start() {
        moveSpeed = 1f;
    }

    // Update is called once per frame
    void Update() {


        if (Input.GetAxis("Horizontal") != 0 && !moving) {
            int leftOrRight = Input.GetAxis("Horizontal") < 0 ? -1 : 1;
            posToMove = new Vector3(leftOrRight, 0, 0) + transform.position;
            print(leftOrRight + " left");
            moving = true;
        }
        if (Input.GetAxis("Vertical") != 0 && !moving) {
            int topOrDown = Input.GetAxis("Vertical") < 0 ? -1 : 1;
            posToMove = new Vector3(0, 0, topOrDown) + transform.position;
            moving = true;
        }

        if (posToMove != new Vector3()) {
            transform.position = Vector3.MoveTowards(transform.position, posToMove, 1 * Time.deltaTime);
        }
        if (Vector3.Distance(transform.position, posToMove) < 0.001f) {
            moving = false;
            posToMove = new Vector3();

        }
    }
}
