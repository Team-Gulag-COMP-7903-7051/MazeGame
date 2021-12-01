using UnityEngine;

public class PlayerManager : MonoBehaviour {
    private Vector3 _originalPosition;
    private int _score;

    private void Start() {
        _originalPosition = transform.position;
    }

    public void IncreaseScore() {
        _score++;
    }

    public int Score {
        get { return _score; }
    }

}
