using UnityEngine;
using UnityEngine.SceneManagement;

public class CleaningInteraction : MonoBehaviour, IInteractable
{
    private EventManager _eventManager;
    public string sceneToLoad;
    
    private void Start()
    {
        _eventManager = FindObjectOfType<EventManager>();
    }

    public void Interact()
    {
        gameObject.SetActive(false);

        if (_eventManager == null) return;
        _eventManager.triggerCount++;

        if (_eventManager.triggerCount < _eventManager.maxTriggerCount) return;
        if (string.IsNullOrEmpty(sceneToLoad))
        {
            Debug.LogError("Scene name to load is not specified.");
            return;
        }
        
        SceneManager.LoadScene(sceneToLoad);
    }
}