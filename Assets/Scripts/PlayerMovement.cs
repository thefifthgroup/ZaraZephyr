using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Input.GetAxisRaw makes the character stop immediately after player Input
        float aX = Input.GetAxisRaw("Horizontal");

        // Player's horizontal movement
        rb.velocity = new Vector2(aX * speed, rb.velocity.y);

        // Player jump
        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2 (rb.velocity.x, 14f);
        }
    }
}
