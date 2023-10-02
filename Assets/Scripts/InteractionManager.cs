/*using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionManager : MonoBehaviour
{
    [SerializeField] private GameObject popupPrefab;
    private int _interactedObjectCount = 0;
    private int _requiredObjectCount = 4; // Number of interactions required before sleeping

    // Dictionary to keep track of interactable objects and their popup messages.
    private Dictionary<GameObject, string> interactableObjects = new Dictionary<GameObject, string>();

    private void Start()
    {
        // Add interactable objects and their popup messages to the dictionary.
        interactableObjects.Add(GameObject.FindWithTag("Object1"), "This is the first object's story.");
        interactableObjects.Add(GameObject.FindWithTag("Object2"), "This is the second object's story.");
        // Add more objects as needed.
    }

    public void InteractWithObject(GameObject obj)
    {
        // Check if the object is in the dictionary of interactable objects.
        if (interactableObjects.ContainsKey(obj))
        {
            var popupMessage = interactableObjects[obj];
            ShowPopup(popupMessage);
            _interactedObjectCount++;

            if (_interactedObjectCount >= _requiredObjectCount)
            {
                // Player has interacted with all required objects.
                // Allow them to go to sleep or transition to the next level.
            }
        }
        else
        {
            // The object is not in the dictionary, so it's not one of the required objects.
            // Show a different popup message, e.g., "Have a look around."
            ShowPopup("Have a look around.");
        }
    }

    private void ShowPopup(string message)
    {
        // Instantiate the popup prefab and set its text.
        GameObject popup = Instantiate(popupPrefab, transform);
        var popupText = popup.GetComponentInChildren<Text>();
        popupText.text = message;
    }
}*/