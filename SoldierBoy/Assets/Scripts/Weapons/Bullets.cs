using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    private float timeToDestroy = 3.0f;

    private void Update()
    {
        timeToDestroy -= Time.deltaTime;
        if (timeToDestroy <= 0.0f)
        {
            Destroy(gameObject);
            timeToDestroy = 3.0f;
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
