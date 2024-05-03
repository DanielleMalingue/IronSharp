using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonColorFill : MonoBehaviour
{
    public Image[] buttonSprites; // Array to hold all the sprite buttons
    public Color fillColor = Color.green; // Color to fill the buttons with
    public float fillDuration = 1f; // Duration for filling each button
    public TMP_Text messageText; // Reference to the TextMeshPro text

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
            // Display the message
            messageText.text = "Sorry, you are not at the right location.";

            currentIndex++;
        }
        else
        {
            Debug.LogWarning("All buttons have been filled.");
        }
    }
}
