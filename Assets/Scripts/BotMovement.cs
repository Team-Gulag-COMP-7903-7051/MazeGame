using UnityEngine;

public class BotMovement : MonoBehaviour
{
    [SerializeField] private CharacterController _controller;
    [SerializeField] private float _speed;
    private int _rot;

    void Update() {
        Vector3 move = transform.forward;

        _controller.Move(move * _speed * Time.deltaTime);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit) {
        int dir = 90;

        if (Random.Range(0, 2) == 0) {
            dir *= -1;
        }

        if (_rot >= 360 || _rot <= -360) {
            _rot = 0;
        }
        _rot += dir;
        transform.rotation = Quaternion.Euler(0, _rot, 0);
    }

    private void OnValidate() {
        if (_speed < 1) {
            _speed = 1;
        }
    }
}
