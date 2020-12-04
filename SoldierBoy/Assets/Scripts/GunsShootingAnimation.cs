using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunsShootingAnimation : MonoBehaviour
{
    private Animator gunsAnimation;

    private void Start()
    {
        gunsAnimation = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            gunsAnimation.SetBool("isShooting", true);
        }
        else
        {
            gunsAnimation.SetBool("isShooting", false);
        }
    }
}
