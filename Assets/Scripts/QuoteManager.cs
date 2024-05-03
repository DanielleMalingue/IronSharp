using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuoteManager : MonoBehaviour
{
    public TextMeshProUGUI quoteText;
    public Button changeButton;
    public string defaultQuote = "Quote of the day";
    public string stringToDisplay = "String";

    private bool isQuoteDisplayed = true;

    void Start()
    {
        // Set the default quote when the scene starts
        UpdateQuote(defaultQuote);

        // Add a listener to the button
        changeButton.onClick.AddListener(OnChangeButtonClick);
    }

    void OnChangeButtonClick()
    {
        if (isQuoteDisplayed)
        {
            // If quote is displayed, change it to the string
            UpdateQuote(stringToDisplay);
        }
        else
        {
            // If string is displayed, change it back to the quote
            UpdateQuote(defaultQuote);
        }

        // Toggle the flag
        isQuoteDisplayed = !isQuoteDisplayed;
    }

    void UpdateQuote(string newQuote)
    {
        quoteText.text = newQuote;
    }
}
