using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed = 4f; // Movement speed  
    [SerializeField]
    private float jumpSpeed = 5f;    // Jump force  
    [SerializeField]
    private float gravity = 9.8f;    // Gravity strength  

    private Vector3 velocity;        // Tracks vertical velocity  
    private bool isGrounded;         // Is the player on the ground  

    // Ground height for the player  
    private float groundHeight = 2.02f;

    // Animator component  
    private Animator _animator;

    void Start()
    {
        // Get the Animator component from the object  
        _animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        // Check if the player is grounded  
        isGrounded = transform.position.y <= groundHeight + 0.1f;

        // Horizontal movement  
        Vector3 movement = Input.GetAxis("Horizontal") * transform.right +
                           Input.GetAxis("Vertical") * transform.forward;

        // Normalize and apply movement  
        if (movement.magnitude > 1)
        {
            movement.Normalize();
        }
        transform.position += movement * movementSpeed * Time.deltaTime;

        // Handle jumping  
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            velocity.y = jumpSpeed; // Add jump force  
        }

        // Apply gravity  
        if (!isGrounded)
        {
            _animator.SetBool("jumping", true);
            velocity.y -= gravity * Time.deltaTime; // Apply gravity when airborne  
        }
        else
        {
            _animator.SetBool("jumping", false);
        }

        // Apply vertical movement  
        transform.position += new Vector3(0, velocity.y * Time.deltaTime, 0);

        // Prevent sinking below ground  
        if (transform.position.y < groundHeight)
        {
            transform.position = new Vector3(transform.position.x, groundHeight, transform.position.z);
            velocity.y = 0; // Reset velocity when hitting the ground  
        }

        // Update animator speed based on movement  
        UpdateAnimator(movement);
    }

    private void UpdateAnimator(Vector3 movement)
    {
        // Check if the player is moving  
        if (movement.magnitude > 0)
        {
            _animator.SetFloat("speed", 1); // Set speed parameter to 1 when moving  
        }
        else
        {
            _animator.SetFloat("speed", 0); // Set speed parameter to 0 when not moving  
        }
    }
}