using System.Collections;
using UnityEngine;

public class BotMovement : MonoBehaviour {
    [SerializeField] private float _speed;
    [SerializeField] private float _respawnTime;

    private Vector3 _moveDir;
    private Rigidbody _rigidBody;
    private int _dirNum = 0;
    private readonly Vector3[] _dirArray = { Vector3.back, Vector3.left, Vector3.forward, Vector3.right };
    // Prevents bot from changing directions when moving alongside a wall.
    // Used to compare the y-axis of every new wall prefab it encounters.
    private float _lastWallRot;
    private BoxCollider _collider;
    private SkinnedMeshRenderer _renderer;

    private void Awake() {
        _moveDir = Vector3.back;
        _rigidBody = GetComponent<Rigidbody>();
        _collider = GetComponent<BoxCollider>();
        _renderer = GetComponentInChildren<SkinnedMeshRenderer>();
        _lastWallRot = -1;

    }

    private void changeDir() {

        _dirNum++;
        if (_dirNum > 3) {
            _dirNum = 0;
        }

        _moveDir = _dirArray[_dirNum];
    }

    private void FixedUpdate() {
        _rigidBody.velocity = _moveDir * _speed;
    }

    private void OnCollisionEnter(Collision collision) {
        GameObject obj = collision.gameObject;
        if (obj.CompareTag("Wall") && obj.transform.rotation.y != _lastWallRot || obj.CompareTag("Player")) {
            _lastWallRot = obj.transform.rotation.y;
            changeDir();
        } else if (obj.CompareTag("Ball")) {
            _collider.enabled = false;
            _renderer.enabled = false;
            _rigidBody.constraints = RigidbodyConstraints.FreezeAll;
            StartCoroutine(RespawnCoroutine(_respawnTime));
        }
    }

    IEnumerator RespawnCoroutine(float time) {
        yield return new WaitForSeconds(time);
        _collider.enabled = true;
        _renderer.enabled = true;
        _rigidBody.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
        RandomRespawn();
    }

    private void RandomRespawn() {
        int x = Random.Range(-4, 6);
        int z = Random.Range(-4, 6);
        transform.position = new Vector3(x, 0, z);
    }

    private void OnValidate() {
        if (_speed < 0) {
            _speed = 0;
        }

        if (_respawnTime < 0) {
            _respawnTime = 0;
        }
    }
}
