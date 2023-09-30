using UnityEngine;

public class CleanMe : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Debug.Log("Interacted with " + gameObject.name);
        gameObject.SetActive(false);
    }
}
