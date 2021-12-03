using System.Collections;
using UnityEngine;

public class Ball : MonoBehaviour {
    [SerializeField] private float _lifespan = 3;

    private Rigidbody _rigidBody;
    private AudioSource _audioSource;

    private void Awake() {
        _rigidBody = GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();
        StartCoroutine(LifespanCoroutine());
    }

    IEnumerator LifespanCoroutine() {
        yield return new WaitForSeconds(_lifespan);
        Destroy(gameObject);
    }
    private void OnCollisionEnter(Collision col) {
        if (col.gameObject.CompareTag("Wall") || 
            col.gameObject.CompareTag("Dude") || 
            col.gameObject.CompareTag("Floor")) {
            _audioSource.Play();
        }
    }
    public Vector3 Velocity {
        get { return _rigidBody.velocity; }
        set { _rigidBody.velocity = value; }
    }

    private void OnValidate() {
        if (_lifespan < 0.01) {
            _lifespan = 0.01f;
        }
    }


}
