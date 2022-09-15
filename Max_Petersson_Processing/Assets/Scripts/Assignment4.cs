using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assignment4 : ProcessingLite.GP21
{
    private Vector2 circlePosition = Vector2.zero;
    private Vector2 mousePosition;
    private Vector2 startPosition;
    private Vector2 direction = Vector2.zero;
   
    private float speed = 2f; // initiallisera till kanske 1 eller n�got

    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Background(0);

        Circle(circlePosition.x, circlePosition.y, 2f);
       

        if (Input.GetMouseButtonDown(0))
        {
            circlePosition = Vector2.zero;
            circlePosition = mousePosition;
            
        }
        if (Input.GetMouseButton(0))
        {
           // Background(0);
             //h�llet den ska �ka

            Line(circlePosition.x, circlePosition.y, mousePosition.x, mousePosition.y);

            Circle(circlePosition.x, circlePosition.y, 2f);

            
            //rita en linje mellan muspositionen och circelns position
        }
        if (Input.GetMouseButtonUp(0))
        {
            direction = (mousePosition - circlePosition) * speed * Time.deltaTime;
            
        }

        circlePosition = (direction + circlePosition);

        //r�relsen
    }
}
