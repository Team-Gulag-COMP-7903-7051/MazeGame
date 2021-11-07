using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public CharacterController Controller;
    public float Speed = 8f;
    
    private bool _isCharCtrlMove = true;

    void Update() {
        if (_isCharCtrlMove) {
            CharCtrlMove();
        } else {
            TranslateMove();
        }
    }

    public void ChangeMoveType(bool b) {
        _isCharCtrlMove = b;
    }

    void CharCtrlMove() {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        Controller.Move(move * Speed * Time.deltaTime);
    }

    void TranslateMove() {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        Controller.transform.Translate(move * Speed * Time.deltaTime, Space.World);
    }
}
