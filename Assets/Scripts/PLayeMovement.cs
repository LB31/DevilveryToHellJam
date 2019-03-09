using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayeMovement : MonoBehaviour
{
    public float moveSpeed;

    public bool moving;

    public Vector3 posToMove = new Vector3();

    public Animator anim;
    public SpriteRenderer spriteRenderer;

    public delegate void PlateHitEvent();
    public static PlateHitEvent PlateWasHit;

    // Start is called before the first frame update
    void Start() {
        moveSpeed = 1f;
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Cube")) {
            print("cube");
            if(PlateWasHit != null)
            PlateWasHit();
        }
    }

    // Update is called once per frame
    void Update() {


        if (Input.GetAxis("Horizontal") != 0 && !moving) {
            int leftOrRight = Input.GetAxis("Horizontal") < 0 ? -1 : 1;
            if(leftOrRight == -1) {
                anim.SetBool("frontLeft", true);
                spriteRenderer.flipX = false;
            } else {
                anim.SetBool("frontLeft", true);
                spriteRenderer.flipX = true;
            }
            posToMove = new Vector3(leftOrRight, 0, 0) + transform.position;
            print(leftOrRight + " left");
            moving = true;

        } else {
            anim.SetBool("frontLeft", false);
            anim.SetBool("frontLeft", false);
            spriteRenderer.flipX = false;
        }

        if (Input.GetAxis("Vertical") != 0 && !moving) {
            int topOrDown = Input.GetAxis("Vertical") < 0 ? -1 : 1;
            if (topOrDown == -1) {
                anim.SetBool("frontLeft", true);
                spriteRenderer.flipX = true;

            } else {
                anim.SetBool("backRight", true);

            }
            posToMove = new Vector3(0, 0, topOrDown) + transform.position;
            moving = true;

        } else {
            anim.SetBool("backRight", false);
            anim.SetBool("frontLeft", false);
            spriteRenderer.flipX = false;
        }

            if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0) {
            anim.SetBool("idleLeft", true);
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
