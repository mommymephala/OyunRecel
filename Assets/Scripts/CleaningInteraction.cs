using UnityEngine;

public class CleaningInteraction : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Debug.Log("Interacted with " + gameObject.name);
        gameObject.SetActive(false);
    }
}
