using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    [SerializeField] private string levelName;
    private EventManager _eventManager;

    private void Start()
    {
        _eventManager = FindObjectOfType<EventManager>();
    }

    public void LoadLevel()
    {
        if(_eventManager.triggerCount < _eventManager.maxTriggerCount) return;
        SceneManager.LoadScene(levelName);
    }
}