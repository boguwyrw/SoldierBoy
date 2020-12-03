using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunsParameters : MonoBehaviour
{
    [SerializeField]
    private ShootingParameters shootingParameters;
    [SerializeField]
    private Transform bulletStartPosition;
    [SerializeField]
    private Rigidbody bullet;

    private Vector3 bulletDirection;
    private float bulletSpeed;
    private float fireRate;
    private float nextFire;

    private void Start()
    {
        bulletDirection = shootingParameters.shootingDirection;
        bulletSpeed = shootingParameters.bulletSpeed;
        fireRate = shootingParameters.fireRate;
        nextFire = Time.time;
    }

    private void Update()
    {
        if (Input.GetButton("Fire1") && (Time.time > nextFire))
        {
            Rigidbody bulletClone;
            bulletClone = Instantiate(bullet, bulletStartPosition.position, bullet.gameObject.transform.rotation);
            bulletClone.velocity = transform.TransformDirection(bulletDirection * bulletSpeed * Time.deltaTime);
            nextFire = Time.time + fireRate;
        }
    }
}
