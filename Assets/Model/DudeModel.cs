using UnityEngine;

public class DudeModel : MonoBehaviour {
    private GameObject _head;
    private Animator _anim;
    [SerializeField] private float _minSpeed;
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _minRange;
    [SerializeField] private float _maxRange;
    void Start() {
        _head = GameObject.Find("Head");
        _anim = GetComponent<Animator>();
        _anim.Play("Take 001");
    }

    // Unity still uses deltaTime for LateUpdate
    void LateUpdate() {
        RandomRotate(_head);
    }

    private void RandomRotate(GameObject obj) {
        float x = Random.Range(_minRange, _maxRange);
        float y = Random.Range(_minRange, _maxRange);
        float z = Random.Range(_minRange, _maxRange);
        float speed = Random.Range(_minSpeed, _maxSpeed);
        obj.transform.Rotate(new Vector3(x, y, z) * speed * Time.deltaTime);
    }

    private void OnValidate() {
        if (_minSpeed < 1) {
            _minSpeed = 1;
        }

        if (_maxSpeed < 1) {
            _maxSpeed = 1;
        }

        if (_minSpeed > _maxSpeed) {
            Debug.LogWarning("MinSpeed is greater than MaxSpeed.");
        }

        if (_minRange > _maxRange) {
            Debug.LogWarning("MinRange is greater than MaxRange.");
        }
    }
}

