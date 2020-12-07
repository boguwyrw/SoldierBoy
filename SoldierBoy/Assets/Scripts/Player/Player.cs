using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private AudioClip footstep = null;
    [SerializeField]
    private GameObject gameControllerObj = null;

    private float playerSpeed;
    private float playerSpeedValue = 6.0f;
    private AudioSource footstepAS;
    private float timeToPlaySound;
    private GameController gameController;
    private bool isGameOver = false;

    private void Start()
    {
        playerSpeed = playerSpeedValue;
        footstepAS = GetComponent<AudioSource>();
        timeToPlaySound = footstep.length;
        gameController = gameControllerObj.GetComponent<GameController>();
    }

    private void Update()
    {
        float movementVertical = Input.GetAxis("Vertical");
        movementVertical *= Time.deltaTime;
        transform.Translate(Vector3.forward * movementVertical * playerSpeed);

        float movementHorizontal = Input.GetAxis("Horizontal");
        movementHorizontal *= Time.deltaTime;
        transform.Translate(new Vector3(movementHorizontal * playerSpeed, 0.0f, 0.0f));

        GameOver();
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

    private void GameOver()
    {
        isGameOver = gameController.GetGameOver();

        if (!isGameOver)
        {
            playerSpeed = playerSpeedValue;
            PlayFootstepSound();
        }
        else
        {
            playerSpeed = 0.0f;
            gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        }
    }
}
