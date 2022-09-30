using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assignment5Velocity : ProcessingLite.GP21
{
    private float directionX;
    private float directionY;
    private float positionX;
    private float positionY;
    private float radius = 3f;

    [SerializeField] private float speedLimit = 40f;
    [SerializeField] private float acceleration = 40f;
    [SerializeField] private float deAcc = 10f;
    [SerializeField] private float velocity = 3f;
    private bool activateDeAcc = false;

    void Update()
    {
        Background(0, 0, 0);

        if (positionY > Height - radius || positionY < radius)
        {
            directionY *= -1f;
        }
        if (positionX > Width - radius)
        {
            positionX -= Width;
        }
        if(positionX < radius)
        {
            positionX += Width;
        }

        if (Input.GetButton("Vertical") == true || Input.GetButton("Horizontal") == true)
        {
            directionY = Input.GetAxis("Vertical");
            directionX = Input.GetAxis("Horizontal");
            velocity += acceleration * Time.deltaTime;
            activateDeAcc = false;

            if (velocity > speedLimit)
            {
                velocity = speedLimit;
            }
        }
        else if (Input.GetButtonUp("Vertical") || Input.GetButtonUp("Horizontal"))
        {
            activateDeAcc = true;
        }

        if (activateDeAcc == true)
        {
            velocity -= deAcc * Time.deltaTime;
            if (velocity <= 0f)
            {
                velocity = 0f;
            }
        }
        
        positionY += velocity * directionY * Time.deltaTime;
        positionX += velocity * directionX * Time.deltaTime;
        
        Circle(positionX + Width, positionY, radius);
        Circle(positionX , positionY , radius);
        Circle(positionX - Width, positionY , radius);
       
       
    }
   
}
