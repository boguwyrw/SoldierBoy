using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float playerSpeed = 8.0f;

    private void Update()
    {
        float movementVertical = Input.GetAxis("Vertical");
        movementVertical *= Time.deltaTime;
        transform.Translate(Vector3.forward * movementVertical * playerSpeed);

        float movementHorizontal = Input.GetAxis("Horizontal");
        movementHorizontal *= Time.deltaTime;
        transform.Translate(new Vector3(movementHorizontal * playerSpeed, 0.0f, 0.0f));
    }
}
