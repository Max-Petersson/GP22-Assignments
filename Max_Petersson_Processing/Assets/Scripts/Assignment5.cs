using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assignment5 : ProcessingLite.GP21
{
    // Start is called before the first frame update
    private float dirx;
    private float diry;
    private float rad = 5f;
    private float speed = 5f;
   
  
    void Update()
    {
        Background(0, 0, 0);

        diry += Input.GetAxis("Vertical") * speed * Time.deltaTime;
        dirx += Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        
        Circle(dirx, diry, rad);
        
    }
}
