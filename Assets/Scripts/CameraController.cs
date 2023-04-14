using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _distance;
    [SerializeField] private float _lift = 5f;
    private float _startLift;

    private Camera _currentCamera;

    private void Start()
    {
        _currentCamera = Camera.main;
        
        _startLift = _currentCamera.orthographicSize;
    }

    void FixedUpdate()
    {
        var _playerController = _target.gameObject.GetComponent<PlayerController>();

        transform.position = new Vector3(0, 0, _distance) + _target.position;
        transform.LookAt(_target);

        if (_playerController.isMove)
        {
            _currentCamera.orthographicSize = Mathf.Lerp(_currentCamera.orthographicSize, _startLift, Time.fixedDeltaTime * 1.5f);
        }
        else
        {
            _currentCamera.orthographicSize = Mathf.Lerp(_currentCamera.orthographicSize, _lift, Time.fixedDeltaTime);
        }
    }
}
