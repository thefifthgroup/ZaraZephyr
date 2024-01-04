using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float jumpStrength;
    [SerializeField] private LayerMask jumpFloor;

    private Rigidbody2D rb;
    private BoxCollider2D boxc;
    private Animator anim;
    private SpriteRenderer sprite;
    private float aX = 0f;

    // setting a variable that contains only the four player animation/movement states
    private enum AnimationState { idle, run, jump, fall }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        boxc = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        // Input.GetAxisRaw makes the character stop immediately after player Input
        aX = Input.GetAxisRaw("Horizontal");

        // Player's horizontal movement
        rb.velocity = new Vector2(aX * movementSpeed, rb.velocity.y);

        // Player jump
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2 (rb.velocity.x, jumpStrength);
        }

        UpdateAnimationState();

    }
    private void UpdateAnimationState()
    {
        AnimationState state;
        // Player run
        // if aX is 0 then player is idle

        // run animation to the right 
        if (aX > 0f)
        {
            state = AnimationState.run;
            sprite.flipX = false;
        }
        // run animation to the left
        else if (aX < 0f)
        {
            state = AnimationState.run;
            sprite.flipX = true;
        }
        // else, player is idle
        else
        {
            state = AnimationState.idle; 
        }
        
        // check for player jumping
        if (rb.velocity.y > .1f)
        {
            state = AnimationState.jump;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = AnimationState.fall;
        }
        anim.SetInteger("animState", (int)state);
    }
    
    private bool IsGrounded()
    {
        // checks if the player is overlapping the terrain/ground
        return Physics2D.BoxCast(boxc.bounds.center, boxc.bounds.size, 0f, Vector2.down, .1f, jumpFloor);
    }
}
