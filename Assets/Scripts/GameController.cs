using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class GameController : MonoBehaviour {
    [SerializeField] private CharacterController _player;
    private InputActions _inputActions; // Input Actions 'Controller'
    private InputAction _godMode;
    private InputAction _reset;
    private InputAction _quit;

    private bool IsGodMode = false;

    private void Awake() {
        _inputActions = new InputActions();
        _godMode = _inputActions.Player.GodMode;
        _reset = _inputActions.Player.Reset;
        _quit = _inputActions.Player.Quit;
    }

    private void OnEnable() {
        _godMode.Enable();
        _reset.Enable();
        _quit.Enable();

        // Assign callback functions for each action
        _godMode.performed += GodModeCallback;
        _reset.performed += ResetCallback;
        _quit.performed += QuitCallback;
    }

    private void OnDisable() {
        _godMode.Disable();
        _reset.Disable();
        _quit.Disable();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Home)) {
            ResetPosition();
        }

        if (Input.GetKeyDown(KeyCode.G)) {
            ToggleGodMode();
        }
    }

    // Toggle the player's ability to phase through walls.
    private void ToggleGodMode() {
        IsGodMode = !IsGodMode;

        if (IsGodMode) {
            // Use Translate to move, ignore wall colliders
            _player.GetComponent<PlayerMovement>().ChangeMoveType(false);
        } else {
            // Use Character Controller Movement
            _player.GetComponent<PlayerMovement>().ChangeMoveType(true);
        }
    }

    private void ResetPosition() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void GodModeCallback(InputAction.CallbackContext obj) {
        ToggleGodMode();
    }

    private void ResetCallback(InputAction.CallbackContext obj) {
        ResetPosition();
    }

    private void QuitCallback(InputAction.CallbackContext obj) {
        SceneManager.LoadScene("MainMenu");
    }
}
