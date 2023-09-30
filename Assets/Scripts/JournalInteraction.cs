using UnityEngine;

public class JournalInteraction : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Debug.Log("Interacted with " + gameObject.name);
    }
}
