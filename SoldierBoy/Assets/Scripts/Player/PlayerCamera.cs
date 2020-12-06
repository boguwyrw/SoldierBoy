using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField]
    private GameObject gameControllerObj = null;

    private Vector2 mouseDirection;
    private Transform playerBody;
    private float verticalRotation = 0.0f;
    private float horizontalRotation = 0.0f;
    private float rotationLimit = 45.0f;
    private GameController gameController;
    private bool isGameOver = false;

    private void Start()
    {
        playerBody = transform.parent;
        gameController = gameControllerObj.GetComponent<GameController>();
    }

    private void Update()
    {
        isGameOver = gameController.GetGameOver();

        if (!isGameOver)
            CameraMovement();
    }

    private void CameraMovement()
    {
        horizontalRotation = Input.GetAxis("Mouse X");
        verticalRotation = Input.GetAxis("Mouse Y");

        Vector2 mouseChange = new Vector2(horizontalRotation, verticalRotation);

        mouseDirection += mouseChange;

        mouseDirection.y = Mathf.Clamp(mouseDirection.y, -rotationLimit, rotationLimit);
        transform.localRotation = Quaternion.AngleAxis(-mouseDirection.y, Vector3.right);
        playerBody.localRotation = Quaternion.AngleAxis(mouseDirection.x, Vector3.up);
    }
}
