using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public CharacterController Controller;
    public float Speed = 8f;
    
    private bool _isCharCtrlMove = true;
    private AudioManager _audioManager;
    private Vector3 _lastPosition = new Vector3(0, -10, 0);

    private void Awake() {
       _audioManager = FindObjectOfType<AudioManager>();
    }

    void Update() {
        if (_isCharCtrlMove) {
            CharCtrlMove();
        } else {
            TranslateMove();
        }

        if (transform.position != _lastPosition) {
            _lastPosition = transform.position;

            if (!_audioManager.IsPlaying("Footsteps")) {
                _audioManager.Play("Footsteps");
            }
        } else {
            _audioManager.Stop("Footsteps");
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
