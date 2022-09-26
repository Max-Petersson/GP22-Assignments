using System.Collections;
using System.Collections.Generic;
using UnityEngine;


class Ball : ProcessingLite.GP21
{
    //Our class variables
    Vector2 position; //Ball position
    Vector2 velocity; //Ball direction
    float radius;
    public int color1;
    public int color2;
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
        color1 = Random.Range(0, 255);
        color2 = Random.Range(0, 255);
        
        
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
    // fixa väggar
    public void Walls()
    {
        if(this.position.x > Width - radius || this.position.x < radius)
        {
            this.velocity.x *= -1f;
        }
        if(this.position.y > Height - radius || this.position.y < radius)
        {
            this.velocity.y *= -1f;
        }
        //kanske går att fixa så att den inte är stuck
    }
}
