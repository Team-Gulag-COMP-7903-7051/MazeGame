using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public CharacterController Controller;
    public float Speed = 8f;

    void Update() {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        Controller.Move(move * Speed * Time.deltaTime);
    }
}
