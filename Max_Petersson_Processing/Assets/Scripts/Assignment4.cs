using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assignment4 : ProcessingLite.GP21
{
    private Vector2 circlePosition = Vector2.zero;
    private Vector2 mousePosition;
    private Vector2 direction = Vector2.zero;

    private float maxSpeed = 0.04f;
    private float radius = 2f;
    private float speed = 2f; // initiallisera till kanske 1 eller något

    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Background(0);

        Circle(circlePosition.x, circlePosition.y, radius);
       

        if (Input.GetMouseButtonDown(0))
        {
            circlePosition = Vector2.zero;
            direction = Vector2.zero;
            circlePosition = mousePosition;
            
        }
        if (Input.GetMouseButton(0))
        {
           // Background(0);
             //hållet den ska åka

            Line(circlePosition.x, circlePosition.y, mousePosition.x, mousePosition.y);

            Circle(circlePosition.x, circlePosition.y, 2f);

            
            //rita en linje mellan muspositionen och circelns position
        }
        if (Input.GetMouseButtonUp(0))
        {
            
            direction = (mousePosition - circlePosition) * speed * Time.deltaTime;
            
        }
        //circelns rörelse
       //0.04 och 0.04
        if(direction.x > maxSpeed)
        {
            direction = direction.normalized * maxSpeed; 
        }
        else if(direction.x < maxSpeed * -1f)
        {
            direction = direction.normalized * maxSpeed;
        }
        if (direction.y > maxSpeed)
        {
            direction = direction.normalized * maxSpeed;
        }
        else if(direction.y < maxSpeed * -1f)
        {
            direction = direction.normalized * maxSpeed;
        }

        circlePosition = (direction + circlePosition);
       
        
        if(circlePosition.x > Width-radius || circlePosition.x <  radius)
        {
            direction.x *= -1f;
        }
        if(circlePosition.y > Height-radius || circlePosition.y < radius)
        {
            direction.y *= -1f;
        }
        //rörelsen
    }
}
