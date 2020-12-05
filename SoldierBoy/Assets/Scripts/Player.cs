using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private AudioClip footstep;

    private float playerSpeed = 8.0f;
    private AudioSource footstepAS;
    private float timeToPlaySound;

    private void Start()
    {
        footstepAS = GetComponent<AudioSource>();
        timeToPlaySound = footstep.length;
    }

    private void Update()
    {
        float movementVertical = Input.GetAxis("Vertical");
        movementVertical *= Time.deltaTime;
        transform.Translate(Vector3.forward * movementVertical * playerSpeed);

        float movementHorizontal = Input.GetAxis("Horizontal");
        movementHorizontal *= Time.deltaTime;
        transform.Translate(new Vector3(movementHorizontal * playerSpeed, 0.0f, 0.0f));

        PlayFootstepSound();
    }

    private void PlayFootstepSound()
    {
        footstepAS.clip = footstep;
        timeToPlaySound -= Time.deltaTime;
        if ((Input.GetKey(KeyCode.W)
            || Input.GetKey(KeyCode.S)
            || Input.GetKey(KeyCode.A)
            || Input.GetKey(KeyCode.D))
            && timeToPlaySound <= 0)
        {
            footstepAS.PlayOneShot(footstepAS.clip);
            timeToPlaySound = footstep.length;
        }
    }
}
