using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assignment5 : ProcessingLite.GP21
{
    private float directionX;
    private float directionY;
    private float radius = 5f;
    private float speed = 5f;
   
    void Update()
    {
        Background(0, 0, 0);
        directionY += Input.GetAxis("Vertical") * speed * Time.deltaTime;
        directionX += Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        Circle(directionX, directionY, radius);
    }
}
