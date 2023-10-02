using UnityEngine;
using TMPro;

namespace Lv1
{
    public class JournalInteraction : MonoBehaviour, IInteractable
    {
        public GameObject popupPrefab;
        public TextMeshProUGUI popupText;

        private bool _isInteracting;
        private bool _popupActive;
        private PlayerMovement _playerMovement;
        private PlayerLook _playerLook;
        private EventManager _eventManager;
        private int _currentPageIndex;
        private bool _firstInteraction = true;

        [SerializeField]
        [TextArea(10, 15)]
        private string[] journalPages;
        private CanvasGroup _canvasGroup;

        private void Start()
        {
            _playerMovement = FindObjectOfType<PlayerMovement>();
            _playerLook = FindObjectOfType<PlayerLook>();
            _eventManager = FindObjectOfType<EventManager>();
        }

        public void Interact()
        {
            if (!_isInteracting)
            {
                if (_playerMovement != null)
                    _playerMovement.enabled = false;

                if (_playerLook != null)
                    _playerLook.enabled = false;

                if (!_popupActive)
                {
                    popupPrefab.SetActive(true);
                    _popupActive = true;
                    
                    _currentPageIndex = 0;
                    if (popupText != null)
                        popupText.text = journalPages[_currentPageIndex];
                }

                _isInteracting = true;

                if (!_firstInteraction) return;
                _eventManager.triggerCount++;
                _firstInteraction = false;
            }
            else
            {
                if (_currentPageIndex < journalPages.Length - 1)
                {
                    _currentPageIndex++;
                    if (popupText != null)
                        popupText.text = journalPages[_currentPageIndex];
                }
                else
                {
                    if (_playerMovement != null)
                        _playerMovement.enabled = true;

                    if (_playerLook != null)
                        _playerLook.enabled = true;

                    popupPrefab.SetActive(false);
                    _popupActive = false;
                    _isInteracting = false;
                }
            }
        }
    }
}