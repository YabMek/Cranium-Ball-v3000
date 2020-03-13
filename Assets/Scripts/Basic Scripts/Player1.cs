using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
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

        if (Input.GetKeyDown(KeyCode.UpArrow)) {
                 rigidBody.AddForce(new Vector2(0, 30), ForceMode2D.Impulse);
       } else {
          rigidBody.AddForce(new Vector2(0, 0), ForceMode2D.Impulse); 
       }

      
    }

    private void HandleMovement()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if(Input.GetKey(KeyCode.RightShift)) {
               rigidBody.velocity = new Vector2(10, rigidBody.velocity.y);
            } else {
               rigidBody.velocity = new Vector2(5, rigidBody.velocity.y); 
            }
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
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
