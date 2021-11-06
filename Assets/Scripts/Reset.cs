using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        print("this scene has been reloaded");
    }
    
    void Update()
    {
        ResetPosition();
    }
    public void ResetPosition() {
        if (Input.GetKeyDown("b")|| Input.GetKeyDown(KeyCode.Home)) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
