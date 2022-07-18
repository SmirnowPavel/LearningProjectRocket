using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelTimer : MonoBehaviour
{
    public static LevelTimer Instance;

    [SerializeField] float _maxTime;
    float _currentTime;

    [SerializeField] Image _timer;
    [SerializeField] GameObject _arrow;
    [SerializeField] Sprite _timerWaste;
    [SerializeField] GameObject _arrowWaste;

    bool changed = true;

    private void Awake()
    {
        Instance = this;
        _currentTime = _maxTime;
        _arrowWaste.SetActive(false);
    }

    private void Start()
    {
        LevelController.Instance.onFinished += Stop;
    }
    public bool HasTime()
    {
        return _currentTime > 0;
    }
    private void Update()
    {
        if(changed)
        {
            _currentTime -= Time.deltaTime;
            UpdateView();
        }
    }

    void UpdateView()
    {
        if(HasTime())
        {
            
            var rot = _arrow.transform.eulerAngles;
            rot.z = TimeAge10() * 360;
            _arrow.transform.eulerAngles = rot;
        }
        else
        {
            Stop();
            var rot = _arrow.transform.eulerAngles;
            rot.z = 0;
            _arrow.transform.eulerAngles = rot;
            _timer.sprite = _timerWaste;
            _arrow.SetActive(false);
            _arrowWaste.SetActive(true);
        }
    }
    float TimeAge10()
    {
        return _currentTime / _maxTime;
    }
    public void Stop()
    {
        changed = false;
    }

}
