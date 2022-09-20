using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assignment5Velocity : ProcessingLite.GP21
{
    private float dirx;
    private float diry;
    private float posx;
    private float posy;
    private float rad = 3f;
    private float speedLimit = 60f;
    private float acceleration = 10f;
    private float deAcc = 0.5f;
    private bool blue = false;
    [SerializeField] private float speed = 3f;
    
    void Update()
    {
        Background(0, 0, 0);

        
        if(Input.GetButton("Vertical") == true || Input.GetButton("Horizontal") == true)
        {
            diry = Input.GetAxis("Vertical");
            dirx = Input.GetAxis("Horizontal");
            speed += +acceleration * Time.deltaTime;
            blue = false;
            if (speed > speedLimit)
            {
                speed = speedLimit;
            }
        }
        else if (Input.GetButtonUp("Vertical") || Input.GetButtonUp("Horizontal"))
        {
            blue = true;
        }
        if (blue == true)
        {
            speed -= acceleration * deAcc * Time.deltaTime;
            if (speed <= 0f)
            {
                speed = 0f;
            }
        }
        
        posy += speed * diry * Time.deltaTime;
        posx += speed * dirx * Time.deltaTime;

        Circle(posx, posy, rad);
    }
   
}
