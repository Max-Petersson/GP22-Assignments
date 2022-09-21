using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDemo : ProcessingLite.GP21
{
    Ball myBall;

    // Start is called before the first frame update
    void Start()
    {
        //Use the new keyword to create our ball object.
        myBall = new Ball(5, 5, 2);
    }

    // Update is called once per frame
    void Update()
    {
        myBall.UpdatePos();
        myBall.Draw();
    }
}
