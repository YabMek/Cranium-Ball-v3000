using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    public Animator animator;
    private Rigidbody2D rigidBody;
    public static GameObject character;

    public bool isGrounded = false;
    public Vector2 jump;
    public float jumpForce = 2.0f;

    public float distToGround;

    private bool shouldJump;
    private bool canJump;


    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        jump = new Vector2(0.0f, 2.0f);
    }

    // Update is called once per frame
    void Update()
    {

        HandleMovement();
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, 0.1f);

        if (Input.GetKeyDown(KeyCode.W))
        {
    
            if (isGrounded == true)
            {
                rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                isGrounded = false;
            }
        }




    }

    private void HandleMovement()
    {
        if (Input.GetKey(KeyCode.D))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rigidBody.velocity = new Vector2(20, rigidBody.velocity.y);
            }
            else
            {
                rigidBody.velocity = new Vector2(5, rigidBody.velocity.y);
            }
        }
        else if (Input.GetKey(KeyCode.A))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rigidBody.velocity = new Vector2(-20, rigidBody.velocity.y);
            }
            else
            {
                rigidBody.velocity = new Vector2(-5, rigidBody.velocity.y);
            }
        }
        else
        {
            rigidBody.velocity = new Vector2(0, rigidBody.velocity.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {

            isGrounded = true;
        }
    }

}
