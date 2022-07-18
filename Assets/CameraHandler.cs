using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject background;

    private float _backgroundCircleRadius;

    private float _backgroundNormalSizeX = 0;
    private float _backgroundNormalSizeY = 0;

    private Vector3 _moveDirection;
    private float _rotationSpeed = 2f;

    //private bool _isTurn = false;
    //private float _halfScreenWidth;
    int _turnDirection;

    void Start()
    {
        _moveDirection = new Vector3(0, 1.5f, 0);
        //_halfScreenWidth = Screen.width / 2f;

        SpriteRenderer sr = background.GetComponent<SpriteRenderer>();
        _backgroundNormalSizeX = sr.size.x;
        _backgroundNormalSizeY = sr.size.y;

        float screenAspect = Screen.width / Screen.height;

        _backgroundCircleRadius = Mathf.Sqrt(
                        mainCamera.orthographicSize * mainCamera.orthographicSize* screenAspect * screenAspect + mainCamera.orthographicSize * screenAspect);
        sr.size = new Vector2(_backgroundCircleRadius * 2 + _backgroundNormalSizeX * 2, _backgroundCircleRadius * 2 + _backgroundNormalSizeY * 2);
    }

    void Update()
    {

        if (Input.GetKey(KeyCode.A))
        {
            _turnDirection = 1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            _turnDirection = -1;
        }
        else
            _turnDirection = 0;

        float xComp = (_moveDirection.x * Mathf.Cos(_rotationSpeed * _turnDirection * Time.deltaTime) - _moveDirection.y * Mathf.Sin(_rotationSpeed * _turnDirection * Time.deltaTime));
        float yComp = (_moveDirection.x * Mathf.Sin(_rotationSpeed * _turnDirection * Time.deltaTime) + _moveDirection.y * Mathf.Cos(_rotationSpeed * _turnDirection * Time.deltaTime));
        _moveDirection = new Vector3(xComp, yComp, 0);

        float rotationZ = Mathf.Atan2(_moveDirection.y, _moveDirection.x) * Mathf.Rad2Deg;
        player.transform.rotation = Quaternion.Euler(0f, 0f, rotationZ - 90);
        mainCamera.transform.rotation = Quaternion.Euler(0f, 0f, rotationZ - 90);

        background.transform.Translate(-_moveDirection.x * Time.deltaTime, -_moveDirection.y * Time.deltaTime, 0);

        if (background.transform.position.x >= _backgroundNormalSizeX)
        {
            background.transform.Translate(-_backgroundNormalSizeX, 0, 0);
        }
        if (background.transform.position.x <= -_backgroundNormalSizeX)
        {
            background.transform.Translate(_backgroundNormalSizeX, 0, 0);
        }
        if (background.transform.position.y >= _backgroundNormalSizeY)
        {
            background.transform.Translate(0, -_backgroundNormalSizeY, 0);
        }
        if (background.transform.position.y <= -_backgroundNormalSizeY)
        {
            background.transform.Translate(0, _backgroundNormalSizeY, 0);
        }

    }


}
