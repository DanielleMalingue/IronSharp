using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class Geolocation : MonoBehaviour
{
    public TextMeshProUGUI challengeText;
    public GameObject[] circles; // Array of circle GameObjects
    public Sprite filledCircleSprite; // Sprite image to fill the circle
    public float requiredLatitude;
    public float requiredLongitude;
    public float radius = 10f; // Radius in meters within which the user must be to complete the challenge

    private bool challengeCompleted = false;

    void Start()
    {
        // Start geolocation service
        Input.location.Start();
    }

    void Update()
    {
        if (!challengeCompleted && Input.location.status == LocationServiceStatus.Running)
        {
            // Get user's current location
            float latitude = Input.location.lastData.latitude;
            float longitude = Input.location.lastData.longitude;

            // Calculate distance between user's location and required location
            float distance = CalculateDistance(latitude, longitude, requiredLatitude, requiredLongitude);

            // Check if user is within the required radius
            if (distance <= radius)
            {
                challengeCompleted = true;
                challengeText.text = "Challenge completed!";

                // Fill in circles incrementally
                FillCircles();
            }
            else
            {
                challengeText.text = "You are not at the gym yet.";
            }
        }
    }

    void FillCircles()
    {
        for (int i = 0; i < circles.Length; i++)
        {
            // If the current circle is empty (not filled), fill it with the sprite image
            if (!IsCircleFilled(circles[i]))
            {
                FillCircle(circles[i]);
                break; // Stop filling circles after the first empty one is filled
            }
        }
    }

    bool IsCircleFilled(GameObject circle)
    {
        // Check if the circle has a child object (sprite image) indicating it's filled
        return circle.transform.childCount > 0;
    }

    void FillCircle(GameObject circle)
    {
        // Create a new GameObject as a child of the circle and attach the sprite image
        GameObject imageGO = new GameObject("FilledCircleImage");
        Image image = imageGO.AddComponent<Image>();
        image.sprite = filledCircleSprite;
        image.transform.SetParent(circle.transform, false);
    }

    // Calculate distance between two points using Haversine formula
    float CalculateDistance(float lat1, float lon1, float lat2, float lon2)
    {
        float R = 6371; // Radius of the earth in km
        float dLat = ToRadians(lat2 - lat1);
        float dLon = ToRadians(lon2 - lon1);
        float a = Mathf.Sin(dLat / 2) * Mathf.Sin(dLat / 2) +
                  Mathf.Cos(ToRadians(lat1)) * Mathf.Cos(ToRadians(lat2)) *
                  Mathf.Sin(dLon / 2) * Mathf.Sin(dLon / 2);
        float c = 2 * Mathf.Atan2(Mathf.Sqrt(a), Mathf.Sqrt(1 - a));
        float d = R * c; // Distance in km
        d *= 1000; // Convert to meters
        return d;
    }

    float ToRadians(float degrees)
    {
        return degrees * Mathf.PI / 180;
    }

    void OnDisable()
    {
        // Stop geolocation service
        Input.location.Stop();
    }
    void YourTargetMethod()
{
    Debug.Log("YourTargetMethod() called!"); // Add this line
    // Your method implementation
}

}
