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
    [SerializeField] private float speedLimit = 40f;
    [SerializeField] private float acceleration = 40f;
    [SerializeField] private float deAcc = 10f;
    private bool activateDeAcc = false;
    [SerializeField] private float speed = 3f;
    
    void Update()
    {
        Background(0, 0, 0);

        if (posy > Height - rad || posy < rad)
        {
            diry *= -1f;
        }
        if (posx > Width - rad)
        {
            posx = posx - Width;
        }
        if(posx < rad)
        {
            posx = posx + Width;
        }
       

        if (Input.GetButton("Vertical") == true || Input.GetButton("Horizontal") == true)
        {
            diry = Input.GetAxis("Vertical");
            dirx = Input.GetAxis("Horizontal");
            speed += +acceleration * Time.deltaTime;
            activateDeAcc = false;
            if (speed > speedLimit)
            {
                speed = speedLimit;
            }
        }
        else if (Input.GetButtonUp("Vertical") || Input.GetButtonUp("Horizontal"))
        {
            activateDeAcc = true;
        }
        if (activateDeAcc == true)
        {
            speed -= deAcc * Time.deltaTime;
            if (speed <= 0f)
            {
                speed = 0f;
            }
        }
        
        posy += speed * diry * Time.deltaTime;
        posx += speed * dirx * Time.deltaTime;
        

        Circle(posx + Width, posy, rad);
        Circle(posx , posy , rad);
        Circle(posx - Width, posy , rad);
       
       
    }
   
}
