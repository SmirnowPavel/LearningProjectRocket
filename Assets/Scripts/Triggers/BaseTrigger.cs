using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerEnter();
        }
        if (collision.tag == "Leg")
        {
            LegEnter();
        }
        
         if (collision.tag == "Platform")
        {
            PlatformEnter();
        }
        

    }

    protected virtual void PlayerEnter()
    {

    }

    protected virtual void LegEnter()
    {

    }

    protected virtual void PlatformEnter()
    {

    }
}
