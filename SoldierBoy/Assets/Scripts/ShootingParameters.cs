using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Parameters", menuName = "Shooting Parameters")]
public class ShootingParameters : ScriptableObject
{
    public float bulletSpeed;
    public float fireRate;
}
