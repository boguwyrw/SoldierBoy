using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeMK2 : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 12)
        {
            Destroy(gameObject);
        }
    }
}
