using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarTrigger : BaseTrigger
{
    protected override void PlayerEnter()
    {
        base.PlayerEnter();
        Debug.Log("PlayerEnter");
        LevelController.Instance.CollectStar();
        Destroy(gameObject);
    }
}
