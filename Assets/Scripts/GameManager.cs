using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private readonly float _intialForce = 100f;
    public Ball ball;
    public Paddle paddle;
    public GameState state;
    public GameMode mode;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log($"GameManager Start");
        state = GameState.FirstStart;
        mode = GameMode.Easy;
        ResetGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            ResetGame();
        }


        if (state == GameState.Ended)
        {
            Time.timeScale = 0f;
        }
        
    }

    private void ResetGame()
    {
        paddle.ResetPaddle();
        ball.Reset();
        Time.timeScale = 1f;
        state = GameState.Playing;
        ball.GetComponent<Rigidbody2D>().AddForce(Vector2.up * _intialForce);
    }

    public void BallLost()
    {
        state = GameState.Ended;
    }
}

public enum GameState
{
    FirstStart,
    Playing,
    Ended
}

public enum GameMode
{
    Easy,
    Normal,
    Hard
}
