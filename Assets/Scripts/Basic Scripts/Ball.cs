using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
// This script requires the GameObject to have a Rigidbody2D component
[RequireComponent(typeof(Rigidbody2D))]
public class Ball : MonoBehaviour
{
    private Rigidbody2D m_rb;
    public float forceHeight = 500f;
 
    private void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
    }
 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") && m_rb != null)
        {
            m_rb.velocity = new Vector2(m_rb.velocity.x/1.1f, m_rb.velocity.y);
            m_rb.AddForce(Vector2.up * forceHeight);
            Vector2 something = new Vector2(m_rb.velocity.x/10f, m_rb.velocity.y);
            m_rb.AddForce(something * forceHeight);
        }

    }
}
 
