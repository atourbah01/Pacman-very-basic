using UnityEngine;

public class PacmanObstacleCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if Pacman collides with an obstacle
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            // Stop Pacman's movement
            Rigidbody2D pacmanRigidbody = GetComponent<Rigidbody2D>();
            pacmanRigidbody.velocity = Vector2.zero;
        }
    }
}
