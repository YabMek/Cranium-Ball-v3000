using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    public Animator animator;
    private Rigidbody2D rigidBody;
    public static GameObject character;

    public bool isGrounded;
    public Vector2 jump;
    public float jumpForce = 2.0f;

    public float distToGround;

    private bool shouldJump;
    private bool canJump;

    private bool pressedJ = false;

    public float MagicTimer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        jump = new Vector2(0.0f, 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        print(MagicTimer);
        MagicTimer = MagicTimer + Time.deltaTime;
        HandleMovement();
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, 0.1f);

        if (Input.GetKeyDown(KeyCode.W))
        {
            rigidBody.AddForce(new Vector2(0, 30), ForceMode2D.Impulse);
        }
        else
        {
            rigidBody.AddForce(new Vector2(0, 0), ForceMode2D.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            pressedJ = true;
            print("JJJJJJJ");
            animator.SetBool("Wack", true);
            MagicTimer = 0.0f;

        }
        if (MagicTimer > .2f)
        {
            animator.SetBool("Wack", false);
        }

    }

    private void HandleMovement()
    {
        if (Input.GetKey(KeyCode.D))
        {
            if(Input.GetKey(KeyCode.Space)) {
               rigidBody.velocity = new Vector2(10, rigidBody.velocity.y);
            } else {
               rigidBody.velocity = new Vector2(5, rigidBody.velocity.y); 
            }
        }
        else if (Input.GetKey(KeyCode.A))
        {
            if(Input.GetKey(KeyCode.Space)) {
               rigidBody.velocity = new Vector2(-10, rigidBody.velocity.y);
            } else {
               rigidBody.velocity = new Vector2(-5, rigidBody.velocity.y); 
            }
        }
        else
        {
            rigidBody.velocity = new Vector2(0, rigidBody.velocity.y);
        }
    }

}
