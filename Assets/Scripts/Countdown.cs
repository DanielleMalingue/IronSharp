using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections; 

public class Countdown : MonoBehaviour
{
    public TextMeshProUGUI countdownText;
    public string nextSceneName;
    private int countdownValue = 3;
    private float countdownTimer = 1f;

    void Start()
    {
        // Start the countdown
        StartCoroutine(StartCountdown());
    }

    IEnumerator StartCountdown()
    {
        while (countdownValue > 0)
        {
            countdownText.text = countdownValue.ToString();
            yield return new WaitForSeconds(countdownTimer);
            countdownValue--;
        }

        // Load the next scene
        SceneManager.LoadScene(nextSceneName);
    }
}
