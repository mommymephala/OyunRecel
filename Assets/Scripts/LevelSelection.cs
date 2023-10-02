using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    [SerializeField] private string levelName;

    public void LoadLevel()
    {
        SceneManager.LoadScene(levelName);
    }
}