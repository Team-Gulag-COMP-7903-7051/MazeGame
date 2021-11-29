using UnityEngine;

public class Shooter : MonoBehaviour {
    [SerializeField] private Transform _gun;
    [SerializeField] private Camera _camera;
    [SerializeField] private Ball _ball;
    [SerializeField] private float _speed = 20;

    private Vector3 _destination;
    private readonly Vector3 _centerScreen = new Vector3(0.5f, 0.5f, 0);

    public void Shoot() {
        float raycastDistance = 1000;
        Ray ray = _camera.ViewportPointToRay(_centerScreen);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, raycastDistance)) {
            _destination = hit.point;
        } else {
            _destination = ray.GetPoint(raycastDistance);
        }

        Ball ball = Instantiate(_ball, _gun.position, Quaternion.identity);
        ball.Velocity = (_destination - _gun.position).normalized * _speed;
    }

    private void OnValidate() {
        if (_speed < 0) {
            _speed = 0;
        }
    }
}
