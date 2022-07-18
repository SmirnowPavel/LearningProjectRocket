using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelView : MonoBehaviour
{
    [SerializeField] GameObject _winPanel;
    [SerializeField] GameObject _loosePanel;

    [SerializeField] Image _star;
    [SerializeField] Sprite _fullStar;

    private void Start()
    {
        LevelController.Instance.onFinished += ShowLevelComplete;
        LevelController.Instance.onLoose += ShowLevelFailed;
        LevelController.Instance.onCollectStar += CollectStar;
    }

    void ShowLevelComplete()
    {
        _winPanel.SetActive(true);
    }
    void ShowLevelFailed()
    {
        _loosePanel.SetActive(true);
    }
    void CollectStar()
    {
        _star.sprite = _fullStar;
    }
}
