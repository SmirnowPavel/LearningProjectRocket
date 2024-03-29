using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerViewer : MonoBehaviour
{
    [SerializeField] Image _fuelBar;

    [SerializeField]
    List<Image> _hpImages;

    [SerializeField] Sprite _hasHPSprite;
    [SerializeField] Sprite _notHPSprite;

    void Start()
    {
        Player.Instance.onFuelLevelChanged += UpdateFuelLevel;
        Player.Instance.onHpChange += UpdateHPCount;
    }

    void UpdateHPCount()
    {
        for (int i = 0; i < Player.Instance.HPCount(); i++)
        {
            _hpImages[i].sprite =_hasHPSprite;
        }
        for (int i = Player.Instance.HPCount(); i < _hpImages.Count; ++i)
        {
            _hpImages[i].sprite = _notHPSprite;
        }
        
    }

    void UpdateFuelLevel()
    {
        _fuelBar.fillAmount = Player.Instance.FuelLevel01();
    }
}
