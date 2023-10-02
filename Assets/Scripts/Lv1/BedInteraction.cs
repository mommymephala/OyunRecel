using System.Collections;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

namespace Lv1
{
    public class BedInteraction : MonoBehaviour, IInteractable
    {
        [SerializeField] private Camera bedCamera;
        [SerializeField] private Image fadeImage;
        [SerializeField] private float blinking;
        [SerializeField] private float fadeDuration;
        private bool _isInteracting;
        private GameObject _playerCharacter;
        private EventManager _eventManager;
        private LevelSelection _levelSelection;
        private void Start()
        {
            _playerCharacter = GameObject.FindGameObjectWithTag("Player");
            _eventManager = FindObjectOfType<EventManager>();
            _levelSelection = FindObjectOfType<LevelSelection>();
        }

        public void Interact()
        {
            if(_eventManager.triggerCount < _eventManager.maxTriggerCount) return;
            if (_isInteracting) return;
            StartCoroutine(InteractSequence());
        }

        private IEnumerator InteractSequence()
        {
            yield return Wait();

            _playerCharacter.transform.position = bedCamera.transform.position;

            yield return Blinking();

            bedCamera.gameObject.SetActive(true);

            _playerCharacter.SetActive(false);

            ResetFadeCanvas();

            yield return FadeToBlack();
            
            _levelSelection.LoadLevel();

            _isInteracting = false;
        }

        private static IEnumerator Wait()
        {
            yield return new WaitForSeconds(0.25f);
        }

        private IEnumerator Blinking()
        {
            var elapsedTime = 0f;

            while (elapsedTime < blinking)
            {
                var alpha = Mathf.Lerp(0, 1, elapsedTime / blinking);
                fadeImage.color = new Color(0, 0, 0, alpha);

                elapsedTime += Time.deltaTime;
                yield return null;
            }

            fadeImage.color = new Color(0, 0, 0, 1);
        }
    
        private IEnumerator FadeToBlack()
        {
            var elapsedTime = 0f;

            while (elapsedTime < fadeDuration)
            {
                var alpha = Mathf.Lerp(0, 1, elapsedTime / fadeDuration);
                fadeImage.color = new Color(0, 0, 0, alpha);

                elapsedTime += Time.deltaTime;
                yield return null;
            }

            fadeImage.color = new Color(0, 0, 0, 1);
        }

        private void ResetFadeCanvas()
        {
            fadeImage.color = new Color(0, 0, 0, 0);
        }
    }
}