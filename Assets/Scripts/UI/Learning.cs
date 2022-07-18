using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Learning : MonoBehaviour
{
    [SerializeField]
    List<GameObject> _slides;
    int _currentSlide = 0;

    void Start()
    {
        foreach(var slide in _slides)
        {
            slide.SetActive(false);
        }
        _slides[_currentSlide].SetActive(true);
    }

    public void NextSlide()
    {
        HideCurrent();
        ShowNext();
    }

    private void HideCurrent()
    {
        if( _currentSlide < _slides.Count)
        {
            Time.timeScale = 0;
            _slides[_currentSlide].SetActive(true);
        }
    }

    private void ShowNext()
    {
        if(_currentSlide < _slides.Count)
        {
            Time.timeScale = 0;
            _slides[_currentSlide].SetActive(true);
        }
    }

    public void NexSlideWithDelay(float del)
    {
        StartCoroutine(Next(del));
    }

    IEnumerator Next(float del)
    {
        HideCurrent();
        yield return new WaitForSeconds(del);
        ShowNext();
    }

}
