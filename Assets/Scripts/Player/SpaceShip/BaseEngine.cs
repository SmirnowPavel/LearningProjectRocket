using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseEngine : MonoBehaviour
{
    [SerializeField]
    protected float a_power;
    protected PlayerLogic a_player;
    protected Rigidbody2D a_rigidbody;
    public bool isAcelerate;
    

    public void SetPlayer (PlayerLogic pl)
    {
        a_player = pl;
        a_rigidbody = pl.GetComponent<Rigidbody2D>();
    }

    public virtual void Acelerate(bool isAcel)
    {
        if (isAcel)
        {
            a_rigidbody.AddForceAtPosition(transform.up * a_power * Time.deltaTime * 50, transform.position);

        }
        isAcelerate = isAcel;
    }

}
