using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelController : MonoBehaviour
{
    public static LevelController Instance;

    public event Action onFinished = delegate { };
    public event Action onLoose = delegate { };
    public event Action onCollectStar = delegate { };

    public LevelModel LevelModel;
    int _index;

    [SerializeField]
    List<int> _moneyForStars;

    private void Awake()
    {
        Instance = this;
        LevelModel.starsCount = 1;
    }

    private void Start()
    {
        _index = GlobalLevelController.Instance.GetIndex();
    }

    public void FinishLevel()
    {
        if(LevelModel.loosed)
        {
            return;
        }
        onFinished();
        LevelModel.completed = true;
        ApplyStars();
        Money.AddMoney(EarnedMoney());
    }

    void ApplyStars()
    {
        if(LevelTimer.Instance.HasTime())
            ++LevelModel.starsCount;
        
        InformationAboutLevels.SetStarsCount(_index, LevelModel.starsCount);
    }
    public void CollectStar()
    {
        onCollectStar();
        LevelModel.starsCount = 2;
    }

    public void LooseLevel()
    {
        if(!LevelModel.completed)
        {
            onLoose();
            LevelModel.loosed = true;
        }
    }

    public int EarnedMoney()
    {
        return _moneyForStars[Mathf.Min(LevelModel.starsCount - 1, 2)];
    }


}
