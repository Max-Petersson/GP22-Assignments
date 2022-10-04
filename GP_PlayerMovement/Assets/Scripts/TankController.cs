using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    Rigidbody2D rb;
    private float turningSpeed = 90f;
    private float angle;
    private float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        angle -= Input.GetAxis("Horizontal") * turningSpeed * Time.deltaTime;
        
        rb.MoveRotation(angle);

        float y = Input.GetAxis("Vertical");

        rb.velocity = rb.transform.up * y * speed;
    }
}
