using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    [SerializeField] private CharacterController _player;
    private bool IsGodMode = false;

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
}
