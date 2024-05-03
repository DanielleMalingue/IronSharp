using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class LightBox : MonoBehaviour, IPointerClickHandler
{
    public GameObject lightBoxPanel;

    void Start()
    {
        // Make sure the lightbox panel is inactive when the game starts
        lightBoxPanel.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        ToggleLightBox();
    }

    void ToggleLightBox()
    {
        // Toggle the visibility of the lightbox panel
        lightBoxPanel.SetActive(!lightBoxPanel.activeSelf);
    }
}
