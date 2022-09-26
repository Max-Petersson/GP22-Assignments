using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : ProcessingLite.GP21
{
    // Start is called before the first frame update
    private int maximumBalls = 100;
    private Ball[] balls;
    private float timer = 3f;
    private float timerReset;
    private int amountOfBalls = 0;
    void Start()
    {
        timerReset = timer;
        balls = new Ball[maximumBalls];
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0f)
        {
            if (amountOfBalls <= maximumBalls)
            {
                float x = Random.Range(0, Width - 1f);
                float y = Random.Range(0, Height - 1f);
                float r = Random.Range(1, 3);
                balls[amountOfBalls] = new Ball(x, y, r);
                amountOfBalls++;
            }
           
            timer = timerReset;
            //lägg till en boll i listan tills det finns 100 bollar i listan
        }

        Background(0, 0, 0);

        for (int i = 0; i < amountOfBalls; i++)
        {
            balls[i].Fill(balls[i].color1, balls[i].color2, 0);
            balls[i].Draw();
            balls[i].UpdatePos();
            balls[i].Walls();
            // Spawnar bollar
        }

        
    }
    
}
