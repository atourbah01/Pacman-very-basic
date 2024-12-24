using UnityEngine;

public class Pellet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if Pacman collides with a pellet
        if (collision.gameObject.CompareTag("pellet"))
        {
            // Collect the pellet
            CollectPellet(collision.gameObject);
        }
    }

    private void CollectPellet(GameObject pellet)
    {
        // Increase the score
        GameManager.Instance.PelletEaten();
        // Disable the pellet
        pellet.SetActive(false);
    }
}
