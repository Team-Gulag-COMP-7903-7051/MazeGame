using UnityEngine;
using UnityEngine.InputSystem;

public class MouseLook : MonoBehaviour {
    public float MouseSensitivity = 100f;
    public Transform PlayerBody;
    float xRotation = 0f;

    [SerializeField] private float _joystickSens = 175f;
    private InputActions _inputActions;
    private InputAction _cam;

    private void Awake() {
        _inputActions = new InputActions();
        _cam = _inputActions.Player.Camera;
        _cam.Enable();
    }

    void Start() {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void FixedUpdate() {
        Vector2 v2 = _cam.ReadValue<Vector2>();

        float rStickX = v2.x * _joystickSens * Time.fixedDeltaTime;
        float rStickY = v2.y * _joystickSens * Time.fixedDeltaTime;

        xRotation -= rStickY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        PlayerBody.Rotate(Vector3.up * rStickX);
    }

    void Update() {
        //Using old Input Method
        float mouseX = Input.GetAxis("Mouse X") * MouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * MouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        PlayerBody.Rotate(Vector3.up * mouseX);
    }
}
