using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoController : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public string sceneName;

    private void Start()
    {
        videoPlayer.loopPointReached += EndReached;
    }

    private void EndReached(VideoPlayer vp)
    {
        SceneManager.LoadScene(sceneName);
    }
}