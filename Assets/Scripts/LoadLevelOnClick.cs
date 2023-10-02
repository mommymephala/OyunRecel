using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevelOnClick : MonoBehaviour
{
    public string levelName;

    public void LoadLevel()
    {
        SceneManager.LoadScene(levelName);
    }
}