using UnityEngine;

public class DisableCursor : MonoBehaviour
{
    private void Start()
    {
        CheckForCursor();
    }

    private static void CheckForCursor()
    {
        if (FindObjectOfType<PlayerLook>() != null)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
    }
}
