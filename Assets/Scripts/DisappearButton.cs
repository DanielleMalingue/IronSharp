using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class DisappearButton : MonoBehaviour
{
    private Button button;
    private RectTransform rectTransform;

    void Start()
    {
        // Get the button component
        button = GetComponent<Button>();
        rectTransform = GetComponent<RectTransform>();

        // Add a listener to the button click event
        button.onClick.AddListener(HideButton);
    }

    void HideButton()
    {
        // Animate button scale
        rectTransform.DOScale(Vector3.zero, 0.3f).OnComplete(() => gameObject.SetActive(false));
    }
}
