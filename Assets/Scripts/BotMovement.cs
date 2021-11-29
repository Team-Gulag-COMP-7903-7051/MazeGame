using UnityEngine;

public class BotMovement : MonoBehaviour {
    [SerializeField] private float _speed;

    private Vector3 _moveDir;
    private Rigidbody _rigidBody;
    private int _dirNum = 0;
    private readonly Vector3[] _dirArray = { Vector3.back, Vector3.left, Vector3.forward, Vector3.right };

    private void Awake() {
        _moveDir = Vector3.back;
        _rigidBody = GetComponent<Rigidbody>();
        _rigidBody.velocity = _moveDir * _speed;
    }

    private void changeDir() {
/*        if (Random.Range(0, 2) == 0) {
            _dirNum++;
        } else {
            _dirNum--;
        }*/

        _dirNum++;
        if (_dirNum > 3) {
            _dirNum = 0;
        }

        _moveDir = _dirArray[_dirNum];
        _rigidBody.velocity = _moveDir * _speed;
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Wall")) {
            changeDir();
        } else if (collision.gameObject.CompareTag("Ball")) {
            // Implement death
            print("hit");
        }
    }

    private void OnValidate() {
        if (_speed < 0) {
            _speed = 0;
        }
    }
}
