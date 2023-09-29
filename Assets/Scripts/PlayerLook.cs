using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform camHolder;
    [SerializeField] private Transform orientation;

    [Header("Mouse Sensitivity")]
    [SerializeField] private float mouseSens = 100f;

    //Mouse look variables
    private const float Multiplier = 0.01f;
    private float _mouseX;
    private float _mouseY;
    private float _xRotation;
    private float _yRotation;

    private void Update()
    {
        HandleMouseLook();
    }

    private void HandleMouseLook()
    {
        // Get mouse input
        _mouseX = Input.GetAxisRaw("Mouse X");
        _mouseY = Input.GetAxisRaw("Mouse Y");

        var currentMouseSensitivity = mouseSens;

        _yRotation += _mouseX * currentMouseSensitivity * Multiplier;
        _xRotation -= _mouseY * currentMouseSensitivity * Multiplier;

        // Clamp the X rotation to avoid over-rotation
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);

        // Update camera and orientation rotations
        camHolder.transform.rotation = Quaternion.Euler(_xRotation, _yRotation, 0);
        orientation.transform.rotation = Quaternion.Euler(0, _yRotation, 0);
    }
}