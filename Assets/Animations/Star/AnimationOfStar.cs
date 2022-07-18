using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationOfStar : MonoBehaviour
{
    public GameObject Star;
    private Animator animationStar;

    void Start()
    {
        animationStar = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            animationStar.SetBool("flag", true);

        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            animationStar.SetBool("flag", false);
        }
    }
}
