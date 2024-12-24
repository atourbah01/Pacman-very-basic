using System.Collections;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public float frightenDuration = 15f;
    private bool isFrightened = false;
    private SpriteRenderer spriteRenderer;
    public Sprite[] frightenedSprites; // Array of frightened sprites
    public float spriteChangeDuration = 0.5f; // Duration between sprite changes

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Method to frighten the ghost
    public void Frighten()
    {
        isFrightened = true;
        StartCoroutine(FrightenedSpriteCycle());
        // Add logic to change the ghost's behavior when frightened
        // For example, change the ghost's color or movement pattern
    }

    // Method to calm the ghost after the frighten duration
    public void Calm()
    {
        isFrightened = false;
        StopCoroutine(FrightenedSpriteCycle());
        // Add logic to reset the ghost's behavior to normal
        // For example, revert the ghost's color or movement pattern
    }

    // Coroutine to cycle through frightened sprites
    private IEnumerator FrightenedSpriteCycle()
    {
        while (true)
        {
            for (int i = 0; i < frightenedSprites.Length; i++)
            {
                spriteRenderer.sprite = frightenedSprites[i];
                yield return new WaitForSeconds(spriteChangeDuration);
            }
        }
    }

    // OnCollisionEnter2D method to handle collision with Pacman
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("pacman"))
        {
            if (isFrightened)
            {
                // Handle logic for when Pacman eats a frightened ghost
                GameManager.Instance.GhostEaten(this);
                gameObject.SetActive(false); // Disable the ghost when eaten
            }
            else
            {
                // Handle logic for when Pacman gets eaten by the ghost
                GameManager.Instance.PacmanEaten();
            }
        }
    }
}
