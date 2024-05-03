using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorFill : MonoBehaviour
{
    public Image[] buttonSprites; // Array to hold all the sprite buttons
    public Color fillColor = Color.green; // Color to fill the buttons with
    public float fillDuration = 1f; // Duration for filling each button

    private int currentIndex = 0; // Index of the current button being filled

    void Start()
    {
        // Initialize all buttons to be transparent
        foreach (Image buttonSprite in buttonSprites)
        {
            buttonSprite.color = Color.clear;
        }
    }

    public void FillNextButton()
    {
        if (currentIndex < buttonSprites.Length)
        {
            // Fill the current button with the specified color over the specified duration
            StartCoroutine(FillButtonCoroutine(buttonSprites[currentIndex], fillColor, fillDuration));
            currentIndex++;
        }
        else
        {
            Debug.LogWarning("All buttons have been filled.");
        }
    }

    IEnumerator FillButtonCoroutine(Image buttonSprite, Color targetColor, float duration)
    {
        float elapsedTime = 0f;
        Color startColor = buttonSprite.color;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            buttonSprite.color = Color.Lerp(startColor, targetColor, elapsedTime / duration);
            yield return null;
        }

        // Ensure the button is completely filled with the target color
        buttonSprite.color = targetColor;
    }
}
