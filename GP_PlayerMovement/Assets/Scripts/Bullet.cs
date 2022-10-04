using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float timer = 3f;
    private Rigidbody2D rb;
    private float speed = 10f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * speed;
        rb.gravityScale = 0;
    }
    void Update()
    {
        Destroy(gameObject, timer);
    }
}
