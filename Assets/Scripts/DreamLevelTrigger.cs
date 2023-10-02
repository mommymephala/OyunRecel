using UnityEngine;
using UnityEngine.SceneManagement;

public class DreamLevelTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadScene("Shower_Scene 2");
        }
    }
}
