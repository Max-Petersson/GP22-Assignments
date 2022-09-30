using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ball : ProcessingLite.GP21
{
    //Our class variables
    public Vector2 position; //Ball position
    Vector2 velocity; //Ball direction
    public float radius;
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
    public bool CircleCollision(PlayerMovement player)
    {

        float maxDistance = radius / 2 + player.radius / 2;

        //first a quick check to see if we are too far away in x or y direction
        //if we are far away we don't collide so just return false and be done.
        if (Mathf.Abs(position.x - player.pos.x) > maxDistance || Mathf.Abs(position.y - player.pos.y) > maxDistance)
        {
            return false;
        }
        //we then run the slower distance calculation
        //Distance uses Pythagoras to get exact distance, if we still are to far away we are not colliding.
        else if (Vector2.Distance(position, player.pos) > maxDistance)
        {
            return false;
        }
        //We now know the points are closer then the distance so we are colliding!
        else
        {
            return true;
        }
    }
}
