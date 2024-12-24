using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pacman : MonoBehaviour
{
    public Sprite[] sprites; // Array of Pacman sprites
    public float animationSpeed = 3f; // Speed of animation (sprites per second)

    private SpriteRenderer spriteRenderer;
    private int currentSpriteIndex = 0;
    private float nextSpriteTime = 0f;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (sprites.Length == 0 || spriteRenderer == null)
        {
            Debug.LogError("PacmanAnimation: Missing sprites or SpriteRenderer component.");
            enabled = false; // Disable the script if required components are missing
            return;
        }

        // Set the initial sprite
        spriteRenderer.sprite = sprites[currentSpriteIndex];
    }

    private void Update()
    {
        // Check if it's time to change the sprite
        if (Time.time >= nextSpriteTime)
        {
            // Increment the sprite index
            currentSpriteIndex = (currentSpriteIndex + 1) % sprites.Length;

            // Set the next sprite and calculate the time for the next sprite change
            spriteRenderer.sprite = sprites[currentSpriteIndex];
            nextSpriteTime = Time.time + 1f / animationSpeed;
        }
    }
}
