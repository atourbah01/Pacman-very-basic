using UnityEngine;

public class PowerPellet : MonoBehaviour
{
    public float duration = 15f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("pacman"))
        {
            GameManager.Instance.PowerPelletEaten(this);
            gameObject.SetActive(false); // Disable the power pellet when eaten
        }
    }
}

