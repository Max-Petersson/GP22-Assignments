using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : ProcessingLite.GP21
{
    // Start is called before the first frame update
    private float dirx;
    private float diry;
    private float posx;
    private float posy;
    Vector2 pos;
    private float radius = 2f;
    private float acceleration = 2f;
    private Vector2 velocity;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        dirx = Input.GetAxisRaw("Horizontal");
        diry = Input.GetAxisRaw("Vertical");

        pos.x = dirx;
        pos.y = diry;

        pos.Normalize();

        velocity = new Vector2(2f + acceleration, 2f + acceleration) * Time.deltaTime;
        pos += velocity * Time.deltaTime;

        if (Input.GetButtonUp("Vertical") && Input.GetButtonUp("Horizontal"))
        {
            pos *= 0.5f * Time.deltaTime;
            //deacc
        }

        Circle(pos.x, pos.y, radius);
    }
}
