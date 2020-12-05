using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeMK2 : MonoBehaviour
{
    private GameObject explosiveParticle;

    private void Start()
    {
        explosiveParticle = transform.GetChild(0).gameObject;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 12 || collision.gameObject.layer == 13)
        {
            explosiveParticle.SetActive(true);
            StartCoroutine("GrenadeEffect");
        }
    }

    private IEnumerator GrenadeEffect()
    {
        yield return new WaitForSeconds(0.3f);
        Destroy(gameObject);
    }
}
