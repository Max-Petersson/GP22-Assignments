using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : ProcessingLite.GP21
{
    // Start is called before the first frame update
    private float dirx;
    private float diry;
    public Vector2 pos;
    Vector2 dir;
    public float radius = 1f;
    private float acceleration = 6f;
 
    private float velocity;

    public void Move()
    {
        dirx = Input.GetAxisRaw("Horizontal");
        diry = Input.GetAxisRaw("Vertical");

        if (Input.GetButton("Vertical") || Input.GetButton("Horizontal"))
        {
            velocity += acceleration * Time.deltaTime; //velocity is speed over time
            dir = new Vector2(dirx, diry).normalized;
        }
        else
        {
            velocity *= 1 - 5 * Time.deltaTime; //0.9995
        }

        pos += dir * velocity * Time.deltaTime; // direction times velocity

        
        Fill(0, 0, 0);
        Circle(pos.x, pos.y, radius);
    }
   

}
