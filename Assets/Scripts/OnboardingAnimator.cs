using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class OnboardingAnimator : MonoBehaviour
{
    public RectTransform[] panels; // Array of RectTransforms for the panels
    public float rotationDuration = 1f; // Duration of each rotation
    public Ease easeType = Ease.Linear; // Ease type for rotation

    private int currentPanelIndex = 0; // Index of the currently active panel

    // Start is called before the first frame update
    void Start()
    {
        // Ensure panels array is not null and contains at least one panel
        if (panels == null || panels.Length == 0)
        {
            Debug.LogError("Panels array is not assigned or empty!");
            return;
        }

        // Start the onboarding sequence
        RotateNextPanel();
    }

    // Rotate the next panel in the sequence
    void RotateNextPanel()
    {
        // Rotate the current panel
        panels[currentPanelIndex].DORotate(new Vector3(0f, 90f, 0f), rotationDuration).SetEase(easeType)
            .OnComplete(() =>
            {
                // Deactivate the current panel
                panels[currentPanelIndex].gameObject.SetActive(false);

                // Move to the next panel index
                currentPanelIndex++;

                // Check if all panels have been rotated
                if (currentPanelIndex >= panels.Length)
                {
                    // Reset index for looping
                    currentPanelIndex = 0;
                }

                // Activate the next panel
                panels[currentPanelIndex].gameObject.SetActive(true);

                // Rotate the next panel
                panels[currentPanelIndex].localRotation = Quaternion.Euler(new Vector3(0f, -90f, 0f)); // Set initial rotation
                panels[currentPanelIndex].DORotate(new Vector3(0f, 0f, 0f), rotationDuration).SetEase(easeType)
                    .OnComplete(() =>
                    {
                        // Rotate the next panel after a short delay
                        Invoke("RotateNextPanel", 1f);
                    });
            });
    }

}
