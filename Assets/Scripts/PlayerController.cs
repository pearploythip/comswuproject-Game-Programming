using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    private Animator anim;
    private bool heroMoving;
    private Vector2 lastMove;
    private bool watering;
    public float wateringTime;
    private float waterTimeCounter;
    private bool digging;
    public float digTime;
    private float digTimeCounter;
    private Rigidbody2D myRigidbody;

	// Use this for initialization
	void Start () {
       anim = GetComponent<Animator>();
       myRigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        heroMoving = false;

        if (!watering && !digging)
        {

            if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
            {
                transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
                heroMoving = true;
                lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
            }
            if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
            {
                transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f));
                heroMoving = true;
                lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
            }

            if (Input.GetKeyDown(KeyCode.J))
            {
                waterTimeCounter = wateringTime;
                watering = true;
                myRigidbody.velocity = Vector2.zero;
                anim.SetBool("Watering", true);
            }
            if (Input.GetKeyDown(KeyCode.K))
            {
                digTimeCounter = digTime;
                digging = true;
                myRigidbody.velocity = Vector2.zero;
                anim.SetBool("Dig", true);
            }
        }

        if (waterTimeCounter > 0)
        {
            waterTimeCounter -= Time.deltaTime;
        }
        if (waterTimeCounter <= 0)
        {
            watering = false;
            anim.SetBool("Watering", false);
        }
        if (digTimeCounter > 0)
        {
            digTimeCounter -= Time.deltaTime;
        }
        if (digTimeCounter <= 0)
        {
            digging = false;
            anim.SetBool("Dig", false);
        }
        anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        anim.SetBool("HeroMoving", heroMoving);
        anim.SetFloat("LastMoveX", lastMove.x);
        anim.SetFloat("LastMoveY", lastMove.y);
    }
}
