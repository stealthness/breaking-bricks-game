using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Ball : MonoBehaviour
{
    Rigidbody2D rb;
    public GameManager gameManager;
    private readonly float _forceBounceCoeff = 20f;
    private readonly float _maxVelocity = 12f;
    private readonly float _ballSize = 0.3f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }



    private void OnCollisionExit2D(Collision2D collision)
    {
        
        if (collision.collider.name == "Paddle")
        {
            if (rb.velocity.magnitude < _maxVelocity)
            {
                rb.AddForce(_forceBounceCoeff * Vector2.up);
            }         
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log($"Ball triggered with {collision.name}");
        gameManager.BallLost();
    }

    internal void Reset()
    {
        ResetBall(Vector2.zero);
    }

    public void ResetBall(Vector2 pos)
    {
        transform.position = pos + _ballSize * Vector2.up;
        rb.velocity = Vector3.zero;
    }
}
