using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallManager : ProcessingLite.GP21
{
    // Start is called before the first frame update
    private int maximumBalls = 100;
    private Ball[] balls;
    private float timer = 3f;
    private float timerReset;
    private int amountOfBalls = 0;
    int myInt;
    PlayerMovement player;
    private bool dead;
    
    void Start()
    {
        timerReset = timer;
        balls = new Ball[maximumBalls];
        player = new PlayerMovement();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0f) // Every third seconds do this
        {
            //Add ball to array until there are 100 balls
            if (amountOfBalls <= maximumBalls)
            {
                float x = Random.Range(0, Width - 1f);
                float y = Random.Range(0, Height - 1f);
                float r = Random.Range(1, 3);
                balls[amountOfBalls] = new Ball(x, y, r);
                amountOfBalls++;
            }
           
            timer = timerReset;
            
        }
      
        Background(0, 0, 0);
        
        for (int i = 0; i < amountOfBalls; i++)
        {
            //Logic for the balls
            balls[i].Fill(balls[i].color1, balls[i].color2, 0);
            balls[i].Draw();
            balls[i].UpdatePos();
            balls[i].Walls();
            dead = balls[i].CircleCollision(player);
            if(dead == true)
            {
                PauseGame();
                return;
            }
        }
       
        player.Move();
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
        Text("Game Over", Width/2, Height/2);
    }
    
}
