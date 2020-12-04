using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallEnemy : MonoBehaviour, IEnemy
{
    private int healthPoints = 3;

    public void TakeDamage(int damageValue)
    {
        healthPoints -= damageValue;
        if (healthPoints <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 9)
        {
            Destroy(collision.gameObject);
            TakeDamage(1);
        }

        if (collision.gameObject.layer == 10)
        {
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.layer == 11)
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
