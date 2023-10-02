using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform orientation;
    [SerializeField] private Camera playerCam;
    [SerializeField] private float moveSpeed = 4f;
    [SerializeField] private bool toggleHeadbob = true;
    [SerializeField] private float headbobFrequency = 2f;
    [SerializeField] private float walkHeadbobAmount = 0.1f;
    [SerializeField] private float headbobSpeedMultiplier = 1f;

    private const float Gravity = 9.81f;
    private float _horizontalMovement;
    private float _verticalMovement;
    private Vector3 _moveDirection;
    private Vector3 _originalLocalPosition;
    private float _verticalVelocity;

    private CharacterController _characterController;
    private bool _isCameraNotNull;
    private float _headbobTimer;

    private void Awake()
    {
        _isCameraNotNull = playerCam != null;
        _characterController = GetComponent<CharacterController>();

        if (playerCam != null)
        {
            _originalLocalPosition = playerCam.transform.localPosition;
        }
    }

    private void Update()
    {
        TakeInput();
        MovePlayer();
        HandleHeadbob();
        ApplyGravity();
    }

    private void TakeInput()
    {
        _horizontalMovement = Input.GetAxisRaw("Horizontal");
        _verticalMovement = Input.GetAxisRaw("Vertical");

        _moveDirection = orientation.forward * _verticalMovement + orientation.right * _horizontalMovement;
    }

    private void MovePlayer()
    {
        _characterController.Move(_moveDirection.normalized * (moveSpeed * Time.deltaTime));
    }

    private void ApplyGravity()
    {
        // Apply gravity to the vertical velocity.
        if (!_characterController.isGrounded)
        {
            _verticalVelocity -= Gravity * Time.deltaTime;
        }
        else
        {
            // Reset vertical velocity when grounded.
            _verticalVelocity = -Gravity * Time.deltaTime;
        }

        // Apply vertical velocity to move the character.
        _characterController.Move(new Vector3(0, _verticalVelocity, 0) * Time.deltaTime);
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