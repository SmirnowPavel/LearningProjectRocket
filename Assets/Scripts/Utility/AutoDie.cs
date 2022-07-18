using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDie : MonoBehaviour
{
    [SerializeField]
    float lifeTime = 0.1f;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }
}