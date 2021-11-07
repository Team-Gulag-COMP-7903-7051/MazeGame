using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNavigation : MonoBehaviour {
    public void LoadScene(string scene) {
        StopAllCoroutines();
        SceneManager.LoadScene(scene);
    }

    public void QuitToMain() {
        SceneManager.LoadScene("MainMenu");
    }
    public void QuitGame() {
        Application.Quit();
    }
}