using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5f; // Pacman movement speed
    private Vector2 direction = Vector2.zero; // Current movement direction

    private void Update()
    {
        // Handle input for movement
        HandleInput();

        // Move Pacman
        Move();
    }

    private void HandleInput()
    {
        // Get input from arrow keys or WASD
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        // Set direction based on input
        if (horizontalInput != 0)
        {
            direction = new Vector2(horizontalInput, 0f);
        }
        else if (verticalInput != 0)
        {
            direction = new Vector2(0f, verticalInput);
        }
    }

    private void Move()
    {
        // Normalize direction to ensure consistent movement speed
        direction.Normalize();

        // Calculate movement amount
        Vector3 movement = new Vector3(direction.x, direction.y, 0f) * speed * Time.deltaTime;

        // Move Pacman
        transform.Translate(movement);
    }

    // Method to reset Pacman's position and direction
    public void ResetState()
    {
        // Set Pacman's position to a starting position
        transform.position = new Vector3(0f, 0f, 0f);

        // Reset Pacman's movement direction
        direction = Vector2.zero;
    }

    // Method to handle Pacman's death sequence (optional)
    public void DeathSequence()
    {
        // Add death sequence logic here (e.g., play animation, show game over screen, etc.)
    }
}

