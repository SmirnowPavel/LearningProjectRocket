using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishTrigger : MonoBehaviour
{
    [SerializeField] private FinishSlider m_finishSlider;
    private int countLegRocket = 2;
    private int counterLeg = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag != "Leg")
        {
            return;
        }
        if(++counterLeg == countLegRocket)
        {
            m_finishSlider.StartSlider();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag != "Leg")
        {
            return;
        }
        if(countLegRocket-- == countLegRocket)
        {
            m_finishSlider.StopSlider();
        }
    }
}
