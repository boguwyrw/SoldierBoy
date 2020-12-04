using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeParameters : MonoBehaviour
{
    [SerializeField]
    private Rigidbody grenadeRigidbody;

    private Transform grenadeClone;
    private Vector3 target;
    private RaycastHit raycastHit;
    private bool canThrow = false;
    private float grenadeRange = 50.0f;

    private void Start()
    {
        CreateGrenadeClone();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && grenadeClone != null)
        {
            Vector3 centerPoint = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));
            if (Physics.Raycast(centerPoint, Camera.main.transform.forward, out raycastHit, grenadeRange))
            {
                target = raycastHit.point;
            }
            else
            {
                target = centerPoint + Camera.main.transform.forward * grenadeRange;
            }

            grenadeClone.parent = null;
            grenadeClone.GetComponent<Rigidbody>().useGravity = true;
            canThrow = true;
        }

        if (canThrow && grenadeClone != null) 
        { 
            grenadeClone.position = Vector3.MoveTowards(grenadeClone.position, target, 15 * Time.deltaTime);
        }
        
        if (grenadeClone == null)
        {
            canThrow = false;
            CreateGrenadeClone();
        }
    }

    private void CreateGrenadeClone()
    {
        grenadeClone = Instantiate(grenadeRigidbody.gameObject.transform, transform.position, transform.rotation);
        grenadeClone.parent = transform;
        grenadeClone.GetComponent<Rigidbody>().useGravity = false;
    }
}
