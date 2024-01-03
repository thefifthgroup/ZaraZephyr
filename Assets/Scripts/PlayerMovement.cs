using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;
    private float aX = 0f;
    [SerializeField] private float movementspeed;
    [SerializeField] private float jumpStrength;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        // Input.GetAxisRaw makes the character stop immediately after player Input
        aX = Input.GetAxisRaw("Horizontal");

        // Player's horizontal movement
        rb.velocity = new Vector2(aX * movementspeed, rb.velocity.y);

        // Player jump
        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2 (rb.velocity.x, jumpStrength);
        }

        UpdateAnimationState();

    }
    private void UpdateAnimationState()
    {
        // Player run
        // if aX is 0 then player is idle

        // run animation to the right 
        if (aX > 0f)
        {
            anim.SetBool("running", true);
            sprite.flipX = false;
        }
        // run animation to the left
        else if (aX < 0f)
        {
            anim.SetBool("running", true);
            sprite.flipX = true;
        }
        // else, player is idle
        else
        {
            anim.SetBool("running", false);
        }

    }
}
