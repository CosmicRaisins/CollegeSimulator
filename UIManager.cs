using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI descriptionText;
    public Button[] choiceButtons;

    public EventManager eventManager;
    public Event currentEvent;

    void Start()
    {
        if (eventManager == null)
        {
            Debug.LogError("EventManager reference is not set in the Inspector.");
        }

        // Test if the eventManager is not null before calling its methods
        if (eventManager != null)
        {
            ShowRandomEvent();
        }
        else
        {
            Debug.LogError("EventManager is null. Please assign the reference in the Inspector.");
        }
    }

    void ShowRandomEvent()
    {
        currentEvent = eventManager.GetRandomEvent();

        if (currentEvent != null)
        {
            titleText.text = currentEvent.Name;
            descriptionText.text = currentEvent.Description;

            List<Choice> choices = currentEvent.Choices;
            for (int i = 0; i < choiceButtons.Length; i++)
            {
                if (i < choices.Count)
                {
                    choiceButtons[i].gameObject.SetActive(true);
                    choiceButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = choices[i].Name;
                    int index = i; // Capture the value of i for the callback
                    choiceButtons[i].onClick.RemoveAllListeners();
                    choiceButtons[i].onClick.AddListener(() => OnChoiceSelected(index));
                }
                else
                {
                    choiceButtons[i].gameObject.SetActive(false);
                }
            }
        }
        else
        {
            Debug.LogError("No event loaded.");
        }
    }

    void OnChoiceSelected(int choiceIndex)
    {
        // Handle the selected choice based on your game logic
        Choice selectedChoice = currentEvent.Choices[choiceIndex];
        Debug.Log("Selected Choice: " + selectedChoice.Name);

        // Perform any actions or updates based on the selected choice
    }
}