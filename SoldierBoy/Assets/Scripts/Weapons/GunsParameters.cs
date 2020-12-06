using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunsParameters : MonoBehaviour
{
    [SerializeField]
    private ShootingParameters shootingParameters = null;
    [SerializeField]
    private Transform bulletStartPosition = null;
    [SerializeField]
    private Rigidbody bullet = null;

    private float bulletSpeed;
    private float fireRate;
    private float nextFire;
    private Rigidbody bulletClone;
    private RaycastHit raycastHit;
    private float gunsRange = 50.0f;
    private Vector3 target;

    private void Start()
    {
        bulletSpeed = shootingParameters.bulletSpeed;
        fireRate = shootingParameters.fireRate;
        nextFire = Time.time;
    }

    private void Update()
    {
        if (Input.GetButton("Fire1") && (Time.time > nextFire))
        {
            Vector3 centerPoint = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));

            bulletClone = Instantiate(bullet, bulletStartPosition.position, bullet.gameObject.transform.rotation);
            nextFire = Time.time + fireRate;

            if (Physics.Raycast(centerPoint, Camera.main.transform.forward, out raycastHit, gunsRange))
            {
                target = raycastHit.point;
            }
            else
            {
                target = centerPoint + Camera.main.transform.forward * gunsRange;
            }
        }

        if (bulletClone != null)
            bulletClone.position = Vector3.MoveTowards(bulletClone.position, target, bulletSpeed * Time.deltaTime);
    }
}
