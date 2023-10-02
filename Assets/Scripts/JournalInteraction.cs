using UnityEngine;

public class JournalInteraction : MonoBehaviour, IInteractable
{
    private bool _isInteracting;
    private PlayerMovement _playerMovement;
    private PlayerLook _playerLook;

    private void Start()
    {
        _playerMovement = FindObjectOfType<PlayerMovement>();
        _playerLook = FindObjectOfType<PlayerLook>();
    }

    public void Interact()
    {
        if (!_isInteracting)
        {
            if (_playerMovement != null)
                _playerMovement.enabled = false;
            
            if (_playerLook != null)
                _playerLook.enabled = false;

            _isInteracting = true;
        }
        else
        {
            if (_playerMovement != null)
                _playerMovement.enabled = true;
            
            if (_playerLook != null)
                _playerLook.enabled = true;

            _isInteracting = false;
        }
    }
}