using UnityEngine;

public class BedInteraction : MonoBehaviour, IInteractable
{
    [SerializeField] private Camera bedCamera;
    private GameObject _playerCharacter;
    
    private void Start()
    {
        _playerCharacter = GameObject.FindGameObjectWithTag("Player");
    }
    public void Interact()
    {
        Debug.Log("Interacting.");
        _playerCharacter.SetActive(false);
        bedCamera.gameObject.SetActive(true);
    }
}
