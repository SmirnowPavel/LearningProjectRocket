using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketParticles : MonoBehaviour
{
    private Animator m_Animator;
    private BaseEngine _engine;
    private ParticleSystem _particleSystem;

    void Start()
    {
        m_Animator = GetComponent<Animator>();
        _engine = GetComponent<BaseEngine>();
    }

    void Update()
    {
        if (_engine != null)
        {
            if (_engine.isAcelerate)
            {
                m_Animator.SetBool("Gas", true);
            }
            else
            {
                m_Animator.SetBool("Gas", false);
            }
        }
        if(Input.GetKeyDown(KeyCode.D))
        {
            if(transform.parent.name == "LeftEngine")
            {
                m_Animator.SetBool("Gas", true);
            }
        }
        else if(Input.GetKeyUp(KeyCode.D))
        {
            if(transform.parent.name == "LeftEngine")
           {
                m_Animator.SetBool("Gas", false);
           }
        }

        if(Input.GetKeyDown(KeyCode.A))
        {
            if (transform.parent.name == "RightEngine")
            {
                m_Animator.SetBool("Gas", true);
            }
        }
        else if(Input.GetKeyUp(KeyCode.A))
        {
            if (transform.parent.name == "RightEngine")
            {
                m_Animator.SetBool("Gas", false);
            }
        }
    }

}
