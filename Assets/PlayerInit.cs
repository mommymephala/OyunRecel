using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInit : MonoBehaviour
{
    [SerializeField] private Image fadeImage;
    [SerializeField] private float fadeDuration = 1.0f;

    private void Start()
    {
        StartCoroutine(EyeOpeningSequence());
    }

    private IEnumerator EyeOpeningSequence()
    {
        yield return CloseTheEyes();
        yield return Wait();
        ResetFadeCanvas();
    }

    private IEnumerator CloseTheEyes()
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

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(1f);
    }

    private void ResetFadeCanvas()
    {
        fadeImage.color = new Color(0, 0, 0, 0);
    }
}