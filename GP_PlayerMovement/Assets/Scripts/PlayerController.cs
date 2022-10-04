using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private PolygonCollider2D coll;
    private Vector2 movement;

    private float dirx;
    private float diry;
    private float speed = 5f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<PolygonCollider2D>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        dirx = Input.GetAxis("Horizontal");
        diry = Input.GetAxis("Vertical");
        movement = new Vector2 (dirx, diry) * speed;

        Vector2 mousePos = Input.mousePosition;

        //Use the camera to convert pixel postion to world position
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        //Set our position to the mouse world position
        if(Input.GetMouseButton(0))
            transform.up = (Vector3)mousePos - transform.position;
    }
    private void FixedUpdate()
    {
        rb.velocity = movement;
    }
}
