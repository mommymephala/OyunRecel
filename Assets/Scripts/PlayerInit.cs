using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInit : MonoBehaviour
{
    [SerializeField] private Image fadeImage;
    [SerializeField] private float fadeDuration;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private PlayerLook playerLook;

    private void Start()
    {
        StartCoroutine(EyeOpeningSequence());
    }

    private IEnumerator EyeOpeningSequence()
    {
        if (playerMovement != null)
            playerMovement.enabled = false;

        if (playerLook != null)
            playerLook.enabled = false;

        yield return OpenTheEyes();

        if (playerMovement != null)
            playerMovement.enabled = true;

        if (playerLook != null)
            playerLook.enabled = true;

        ResetFadeCanvas();
    }

    private IEnumerator OpenTheEyes()
    {
        var elapsedTime = 0f;
        var startAlpha = 1f;

        while (elapsedTime < fadeDuration)
        {
            var alpha = Mathf.Lerp(startAlpha, 0, elapsedTime / fadeDuration);
            fadeImage.color = new Color(0, 0, 0, alpha);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        fadeImage.color = new Color(0, 0, 0, 0); // Set alpha to fully transparent.
    }

    private void ResetFadeCanvas()
    {
        fadeImage.color = new Color(0, 0, 0, 0);
    }
}