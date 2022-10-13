using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    [SerializeField] private LayerMask isJumpableGround;  

    private Vector2 movement;
    
    private float dirx;
    [Header("Movement")]
    [SerializeField] private float jumpPower = 6f;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float fallingGravity = 20f;
    [SerializeField] private float actualGravity = 10f;
    private bool doShortHop;
    
    private float cyoteTime = 0.1f;
    private float cyoteTimeCounter;
    private float jumpBuffer = 0.3f;
    private float jumpBufferCounter;

    private Animator anim;
    private SpriteRenderer sprite;
    private enum MovementState { Idle, Running, Jump, Fall }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();

        rb.freezeRotation = true;
       
    }

    void Update()
    {
        dirx = Input.GetAxisRaw("Horizontal");

        movement = new Vector2 (dirx * speed, rb.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            jumpBufferCounter = jumpBuffer;
            doShortHop = false;
        }
        else
        {
            jumpBufferCounter -= Time.deltaTime;
        }
        
        if (Input.GetButtonUp("Jump"))
        {
            cyoteTimeCounter = 0f;
            doShortHop = true;
        }

        if (IsGrounded())
        {
            cyoteTimeCounter = cyoteTime;
            rb.gravityScale = actualGravity;
        }
        else
        {
            cyoteTimeCounter -= Time.deltaTime;
        }

        AnimationUpdate();
    }
    private void FixedUpdate()
    {
        rb.velocity = movement; // move in the x direction

        if (cyoteTimeCounter > 0f && jumpBufferCounter > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            jumpBufferCounter = 0f;
        }
        if (doShortHop == true && rb.velocity.y > .1f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        GravityControl(); //controls falling gravity;
    }
    private void GravityControl()
    {
        if (rb.velocity.y < -.1f && cyoteTimeCounter < 0f)
        {
            rb.gravityScale = fallingGravity;
        }
        else
        {
            rb.gravityScale = actualGravity;
        }
    }
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, isJumpableGround);
    }
    private void AnimationUpdate()
    {
        MovementState state;
        if (dirx > 0 && IsGrounded())
        {
            state = MovementState.Running;
            sprite.flipX = false;
        }
        else if (dirx < 0 && IsGrounded())
        {
            state = MovementState.Running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.Idle;
        }

        if (rb.velocity.y > .1f)
        {
            if (dirx > 0)
                sprite.flipX = false;
            state = MovementState.Jump;
        }
        else if (rb.velocity.y < -.1f)
        {
            if (dirx < 0)
                sprite.flipX = true;
            state = MovementState.Fall;
        }

        anim.Play(state.ToString());

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Collectible"))
        {
            Destroy(collision.gameObject);

            CanvasHandler.score++;
        }
    }
}

