using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoomMode : MonoBehaviour
{
    [SerializeField]
    private Camera playerCamera;

    private Animator smallGunZoomAnim;
    private bool cameraZoom = false;
    private float zoomSpeed = 100.0f;
    private float maxZoom = 30.0f;
    private float minZoom = 60.0f;

    private void Start()
    {
        smallGunZoomAnim = GetComponent<Animator>();
    }

    private void Update()
    {
        ZoomAnimation();

        ZoomINOutSystem();
    }

    private void ZoomAnimation()
    {
        if (Input.GetMouseButtonDown(1))
        {
            smallGunZoomAnim.SetBool("isZoomOut", false);
            smallGunZoomAnim.SetBool("isZoomIn", true);
        }

        if (Input.GetMouseButtonUp(1))
        {
            smallGunZoomAnim.SetBool("isZoomIn", false);
            smallGunZoomAnim.SetBool("isZoomOut", true);
        }
    }

    private void ZoomINOutSystem()
    {
        if (Input.GetMouseButton(1) && playerCamera.fieldOfView >= maxZoom)
        {
            playerCamera.fieldOfView -= zoomSpeed * Time.deltaTime;
        }

        if (playerCamera.fieldOfView <= maxZoom)
        {
            cameraZoom = true;
        }

        if (cameraZoom && playerCamera.fieldOfView <= minZoom)
        {
            playerCamera.fieldOfView += zoomSpeed * Time.deltaTime;
        }

        if (playerCamera.fieldOfView >= minZoom)
        {
            cameraZoom = false;
        }
    }
}
