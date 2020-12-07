using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    private float timeToDestroy;
    private float timeToDestroyValue = 2.0f;

    private void Start()
    {
        timeToDestroy = timeToDestroyValue;
    }

    private void Update()
    {
        timeToDestroy -= Time.deltaTime;
        if (timeToDestroy <= 0.0f)
        {
            Destroy(gameObject);
            timeToDestroy = timeToDestroyValue;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 12)
        {
            Destroy(gameObject);
        }
    }
}
