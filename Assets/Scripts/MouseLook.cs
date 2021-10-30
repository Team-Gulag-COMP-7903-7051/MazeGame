using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerBody;

    //private CharacterController _controller;
    //private PlayerInput _playerInput;
    //private InputAction _movementAction;
    //private Transform _cameraTransform;
    //private Quaternion _targetRotation;
    //private Vector3 _move;
    //private Vector3 _playerVelocity;
    //private float _playerSpeed;
    //private bool _groundedPlayer;

    float xRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        //_controller = GetComponent<CharacterController>();
        //_playerInput = GetComponent<PlayerInput>();
        //_cameraTransform = Camera.main.transform;
        //_movementAction = _playerInput.actions["Move"];
    }

    // Update is called once per frame
    void Update() {

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);



        //_groundedPlayer = _controller.isGrounded;
        //if (_groundedPlayer && _playerVelocity.y < 0) {
        //    _playerVelocity.y = 0f;
        //}

        //// Player movement input
        //Vector2 input = _movementAction.ReadValue<Vector2>();
        ////_move = new Vector3(input.x, 0, input.y); <-- not sure if this is needed
        //_move = input.x * _cameraTransform.right.normalized + input.y * _cameraTransform.forward.normalized;
        //_move.y = 0f;

        //// Player mouse (camera look) input
        //_targetRotation = Quaternion.Euler(0, _cameraTransform.eulerAngles.y, 0);

    }

    //private void FixedUpdate() {
    //    _controller.Move(_move * Time.fixedDeltaTime * _playerSpeed);
    //    _controller.Move(_playerVelocity * Time.fixedDeltaTime);
    //    transform.rotation = Quaternion.Lerp(transform.rotation, _targetRotation, _playerSpeed * Time.fixedDeltaTime);
    //}
}
