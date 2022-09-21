using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : ProcessingLite.GP21
{
    // Start is called before the first frame update
    private int maximumBalls = 100;
    private Ball[] balls;
    private float timer = 3f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ball[] balls = new Ball[maximumBalls];
        for (int i = 0; i < balls.Length; i++)
        {
            float x = Random.Range(0, Width);
            float y = Random.Range(0, Height);
            float r = Random.Range(1, 3);
            balls[i] = new Ball(x, y, r);
        }
        for (int i = 0; i < balls.Length; i++)
        {
            
        }
       
    }
    
}
