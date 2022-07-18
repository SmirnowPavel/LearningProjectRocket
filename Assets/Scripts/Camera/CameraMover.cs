using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraMover : MonoBehaviour
{

    public Transform _target;
    [SerializeField] private float _removalRate = 1.2f;
    [SerializeField] Vector2 _followBounds;
    private float _deltaX;
    private float _normalPlayerY;
    private bool _isStart = false;

    private float _normalCameraY;
    [SerializeField] private float _cameraUpAmplitude = 0.1f;
    private float _normalSize;
    [SerializeField] private GameObject _background;

    [SerializeField] Vector3 _backgroundNormalSize;

    // Start is called before the first frame update
    void Start()
    {
        _normalCameraY = transform.position.y;
        StartFollow();
    }

    // Update is called once per frame
    void Update()
    {
        if (_isStart)
        {
            transform.position = new Vector3(Mathf.Clamp(_target.position.x + _deltaX, _followBounds.x, _followBounds.y),
                _normalCameraY + (_target.transform.position.y - _normalPlayerY) * _cameraUpAmplitude, -100);
            GetComponent<Camera>().orthographicSize = _normalSize + (_target.position.y - _normalPlayerY) * _removalRate;
            RealizeBackground();
        }
    }

    void StartFollow()
    {
        _isStart = true;
        _deltaX = transform.position.x - _target.position.x;
        _normalPlayerY = _target.position.y;
        _normalSize = GetComponent<Camera>().orthographicSize;
        _backgroundNormalSize = _background.transform.localScale;
    } 

    void RealizeBackground()
    {
        var k = 0.075f / 0.4f;
        _background.transform.localScale = _backgroundNormalSize + _backgroundNormalSize * (_target.position.y - _normalPlayerY) * k * _removalRate;
    }


}
