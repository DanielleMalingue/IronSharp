using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorFill : MonoBehaviour
{
    public Image[] buttonSprites; // Array to hold all the sprite buttons
    public Color fillColor = Color.green; // Color to fill the buttons with
    public float fillDuration = 1f; // Duration for filling each button
    public float allowedLatitude = 0f; // Allowed latitude for filling buttons
    public float allowedLongitude = 0f; // Allowed longitude for filling buttons
    public float allowedDistance = 10f; // Allowed distance from the allowed location for filling buttons

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
        StartCoroutine(CheckLocationAndFill());
    }

    IEnumerator CheckLocationAndFill()
    {
        // Start location service
        if (!Input.location.isEnabledByUser)
        {
            Debug.LogWarning("Location service not enabled.");
            yield break;
        }

        Input.location.Start();

        // Wait until location service initializes
        while (Input.location.status == LocationServiceStatus.Initializing)
            yield return null;

        // Check if location service has failed
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            Debug.LogWarning("Location service failed.");
            yield break;
        }

        // Get current GPS coordinates
        float currentLatitude = Input.location.lastData.latitude;
        float currentLongitude = Input.location.lastData.longitude;

        // Calculate distance from allowed location
        float distance = CalculateDistance(currentLatitude, currentLongitude, allowedLatitude, allowedLongitude);

        // Check if distance is within allowed range
        if (distance <= allowedDistance)
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
        else
        {
            Debug.LogWarning("Current location is not within the allowed range.");
        }

        // Stop location service
        Input.location.Stop();
    }

    float CalculateDistance(float lat1, float lon1, float lat2, float lon2)
    {
        var R = 6371; // Radius of the earth in km
        var dLat = deg2rad(lat2 - lat1); // deg2rad below
        var dLon = deg2rad(lon2 - lon1);
        var a =
            Mathf.Sin(dLat / 2) * Mathf.Sin(dLat / 2) +
            Mathf.Cos(deg2rad(lat1)) * Mathf.Cos(deg2rad(lat2)) *
            Mathf.Sin(dLon / 2) * Mathf.Sin(dLon / 2)
            ;
        var c = 2 * Mathf.Atan2(Mathf.Sqrt(a), Mathf.Sqrt(1 - a));
        var d = R * c; // Distance in km
        return d;
    }

    float deg2rad(float deg)
    {
        return deg * (Mathf.PI / 180);
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
