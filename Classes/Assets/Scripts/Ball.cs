using System.Collections;
using System.Collections.Generic;
using UnityEngine;


class Ball : ProcessingLite.GP21
{
    //Our class variables
    Vector2 position; //Ball position
    Vector2 velocity; //Ball direction
    float radius;
    //Ball Constructor, called when we type new Ball(x, y);
    public Ball(float x, float y, float r)
    {
        //Set our position when we create the code.
        position = new Vector2(x, y);
        radius = r;
        //Create the velocity vector and give it a random direction.
        velocity = new Vector2();
        velocity.x = Random.Range(0, 11) - 5;
        velocity.y = Random.Range(0, 11) - 5;
    }

    //Draw our ball
    public void Draw()
    {
        Circle(position.x, position.y, radius);
    }

    //Update our ball
    public void UpdatePos()
    {
        position += velocity * Time.deltaTime;
    }
}
