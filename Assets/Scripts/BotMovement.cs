using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class BotMovement : MonoBehaviour {
    [SerializeField] private float _speed = 1;
    [SerializeField] private float _respawnTime = 5;
    [SerializeField] private int _maxHealth = 3;
    [SerializeField] private MazeRenderer _maze;
    [SerializeField] private TextMeshProUGUI _text;

    private Rigidbody _rigidBody;
    private BoxCollider _collider;
    private SkinnedMeshRenderer _renderer;
    private Vector3 _moveDir;
    private int _dirNum = 0;
    private readonly Vector3[] _dirArray = { Vector3.back, Vector3.left, Vector3.forward, Vector3.right };
    // Prevents bot from changing directions when moving alongside a wall.
    // Used to compare the y-axis of every new wall prefab it encounters.
    private float _lastHitRot;
    private int _currentHealth;
    private int _playerScore;

    private void Awake() {
        _moveDir = Vector3.back;
        _rigidBody = GetComponent<Rigidbody>();
        _collider = GetComponent<BoxCollider>();
        _renderer = GetComponentInChildren<SkinnedMeshRenderer>();
        _lastHitRot = -1;
        _currentHealth = _maxHealth;
        _playerScore = 0;
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

        if (obj.CompareTag("Wall") && obj.transform.rotation.y != _lastHitRot) {
            _lastHitRot = obj.transform.rotation.y;
            changeDir();
        } else if (obj.CompareTag("Ball")) {
            _currentHealth--;
            _playerScore++;
            _text.text = "Score: " + _playerScore;

            if (_currentHealth == 0) {
                _collider.enabled = false;
                _renderer.enabled = false;
                _rigidBody.constraints = RigidbodyConstraints.FreezeAll;
                FindObjectOfType<AudioManager>().Play("Wilhelm");
                StartCoroutine(RespawnCoroutine(_respawnTime));
            }
        } else if (obj.CompareTag("Player")) {
            SceneManager.LoadScene("Maze");
        }
    }

    IEnumerator RespawnCoroutine(float time) {
        yield return new WaitForSeconds(time);
        _currentHealth = _maxHealth;
        _collider.enabled = true;
        _renderer.enabled = true;
        _rigidBody.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
        transform.position = _maze.GetRandomSpawnPoint();
        FindObjectOfType<AudioManager>().Play("WilhelmReversed");
    }

    private void OnValidate() {
        if (_speed < 0) {
            _speed = 0;
        }

        if (_respawnTime < 0) {
            _respawnTime = 0;
        }

        if (_maxHealth < 1) {
            _maxHealth = 1;
        }
    }

    public int PlayerScore {
        get { return _playerScore; }
        set { 
            _playerScore = value;
            _text.text = "Score: " + _playerScore;
        }
    }
}
