using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform orientation;
    [SerializeField] private Camera playerCam;

    [Header("Movement")]
    private const float MovementMultiplier = 10f;
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float acceleration = 10f;
    [SerializeField] private float walkSpeed = 4f;
    [SerializeField] private float groundDrag = 6f;
    private float _horizontalMovement;
    private float _verticalMovement;
    private Vector3 _moveDirection;

    [Header("Headbob")]
    [SerializeField] private bool toggleHeadbob = true;
    [SerializeField] private float headbobFrequency = 2f;
    [SerializeField] private float walkHeadbobAmount = 0.1f;
    [SerializeField] private float headbobSpeedMultiplier = 1f;
    private float _headbobTimer;
    private Vector3 _originalLocalPosition;
    
    //Components
    private Rigidbody _rb;
    private bool _isCameraNotNull;

    private void Awake()
    {
        _isCameraNotNull = playerCam != null;
        _rb = GetComponent<Rigidbody>();
        _rb.freezeRotation = true;
        if (playerCam != null)
        {
            _originalLocalPosition = playerCam.transform.localPosition;
        }
    }

    private void Update()
    {
        TakeInput();
        ControlDrag();
        ControlSpeed();
        HandleHeadbob();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void TakeInput()
    {
        _horizontalMovement = Input.GetAxisRaw("Horizontal");
        _verticalMovement = Input.GetAxisRaw("Vertical");

        _moveDirection = orientation.forward * _verticalMovement + orientation.right * _horizontalMovement;
    }

    private void MovePlayer()
    {
        _rb.AddForce(_moveDirection.normalized * (moveSpeed * MovementMultiplier), ForceMode.Acceleration);
    }

    private void ControlSpeed()
    {
        moveSpeed = Mathf.Lerp(moveSpeed, walkSpeed, acceleration * Time.deltaTime);
    }
    
    private void ControlDrag()
    {
        _rb.drag = groundDrag;
    }

    private void HandleHeadbob()
    {
        if (toggleHeadbob && moveSpeed > 0 && (_horizontalMovement != 0 || _verticalMovement != 0))
        {
            var bobAmount = walkHeadbobAmount;
            var bobAmountX = Mathf.Sin(_headbobTimer) * bobAmount;
            var bobAmountY = Mathf.Cos(_headbobTimer * 2) * bobAmount * 0.5f;

            var headbobOffset = new Vector3(bobAmountX, bobAmountY, 0f);

            // Apply the headbob offset to the camera's local position
            if (_isCameraNotNull)
                playerCam.transform.localPosition =
                    _originalLocalPosition + headbobOffset * headbobSpeedMultiplier;

            // Increment the headbob timer based on the movement speed
            _headbobTimer += moveSpeed * headbobFrequency * Time.deltaTime;
        }
        else
        {
            // Reset headbob when not moving
            playerCam.transform.localPosition = Vector3.Lerp(playerCam.transform.localPosition, _originalLocalPosition, Time.deltaTime * headbobSpeedMultiplier);
            _headbobTimer = 0f;
        }
    }
}