using UnityEngine;
using UnityEngine.SceneManagement;

public class WinTile : MonoBehaviour {
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("GameWinScene"); // Switch to GameWinScene
        }
    }
}
