using TMPro;
using UnityEngine;

public class BaseInteraction : MonoBehaviour, IInteractable
{
    public GameObject popupPrefab;
    [TextArea(3, 10)]
    public string interactionText;
    private bool _isInteracting;
    private PlayerMovement _playerMovement;
    private PlayerLook _playerLook;
    private EventManager _eventManager;
    private bool _hasInteracted;

    private TextMeshProUGUI _popupText;

    private void Start()
    {
        _playerMovement = FindObjectOfType<PlayerMovement>();
        _playerLook = FindObjectOfType<PlayerLook>();
        _eventManager = FindObjectOfType<EventManager>();
        _popupText = popupPrefab.GetComponentInChildren<TextMeshProUGUI>();
    }

    public void Interact()
    {
        if (!_isInteracting)
        {
            if (_playerMovement != null)
                _playerMovement.enabled = false;

            if (_playerLook != null)
                _playerLook.enabled = false;

            popupPrefab.SetActive(true);
            if (_popupText != null)
                _popupText.text = interactionText;
            _isInteracting = true;

            if (_hasInteracted) return;
            _hasInteracted = true;
            _eventManager.triggerCount++;
        }
        else
        {
            if (_playerMovement != null)
                _playerMovement.enabled = true;

            if (_playerLook != null)
                _playerLook.enabled = true;

            popupPrefab.SetActive(false);
            _isInteracting = false;
        }
    }
}