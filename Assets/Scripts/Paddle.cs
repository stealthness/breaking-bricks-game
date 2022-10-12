using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Paddle : MonoBehaviour
{
    private GameManager _gameManager;
    private readonly float TOL = 0.001f;
    private readonly float _forceCoeff = 20f;
    private readonly float _maxSpeed = 6f;
    private readonly Vector3 _intialPaddlePosition = new Vector3(0, -4f, 0);
    private Rigidbody2D _rigidBody;

    private void Awake()
    {
        _gameManager = GetComponent<GameManager>();
        _rigidBody = GetComponent<Rigidbody2D>();
    }


    void Start()
    {
        Debug.Log($"mode: {_gameManager.mode}");
        if (_gameManager.mode == GameMode.Easy)
        {
            transform.localScale = new Vector3(4f,0.2f,1f);
        }
        
    }

    void FixedUpdate()
    {
        float x  = Input.GetAxisRaw("Horizontal");
        if (Math.Abs(x) < TOL)
        {
            return;
        }
        if (_rigidBody.velocity.magnitude > _maxSpeed)
        {
            return;
        }

        if (x > 0)
        {
            _rigidBody.AddForce(_forceCoeff * Vector2.right);
        }
        if (x < 0)
        {
            _rigidBody.AddForce(_forceCoeff * Vector2.left);
            
        }
    }

    public void ResetPaddle()
    {
        transform.position = _intialPaddlePosition;
    }


}
