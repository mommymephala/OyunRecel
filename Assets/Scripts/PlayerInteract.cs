using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private KeyCode interactKey = KeyCode.Mouse0;
    private Camera _camera;
    private bool _isCameraNull;
    private float _maxDistance;

    private void Awake()
    {
        _camera = Camera.main;
        _isCameraNull = _camera == null;
    }

    private void Start()
    {
        _maxDistance = 250f;
    }

    private void Update()
    {
        if (!Input.GetKeyDown(interactKey)) return;
        if (_isCameraNull) return;
        if (!Physics.Raycast(_camera.transform.position, _camera.transform.forward, out RaycastHit hit,
                _maxDistance)) return;
        var interactable = hit.collider.GetComponent<IInteractable>();
        interactable?.Interact();
    }
}