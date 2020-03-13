using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Collision : MonoBehaviour
{

    public float force = 25f;
    public GameObject ball;
    Rigidbody2D rbBall;

    // Start is called before the first frame update
    void Start()
    {

        ball = GameObject.FindGameObjectWithTag("Ball");
        rbBall = ball.GetComponent<Rigidbody2D>();
        this.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Ball")
        {
           print("COLLIDE");
            Vector2 pos = (transform.position - collision.gameObject.transform.position).normalized;
            rbBall.AddForce(-pos * force, ForceMode2D.Impulse);


        }
    }
}
