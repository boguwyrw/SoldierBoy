using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrenadeParameters : MonoBehaviour
{
    [SerializeField]
    private Rigidbody grenadeRigidbody = null;

    private Transform grenadeClone;
    private Vector3 target;
    private RaycastHit raycastHit;
    private bool canThrow = false;
    private float grenadeRange = 50.0f;
    private float throwForce = 15.0f;
    private int numberOfGrenades = 3;

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
            numberOfGrenades--;
        }

        if (canThrow && grenadeClone != null) 
        { 
            grenadeClone.position = Vector3.MoveTowards(grenadeClone.position, target, throwForce * Time.deltaTime);
        }

        if (grenadeClone == null)
        {
            canThrow = false;
            if (numberOfGrenades > 0)
            {
                CreateGrenadeClone();
            }
        }
    }

    private void CreateGrenadeClone()
    {
        grenadeClone = Instantiate(grenadeRigidbody.gameObject.transform, transform.position, transform.rotation);
        grenadeClone.parent = transform;
        grenadeClone.GetComponent<Rigidbody>().useGravity = false;
    }

    public int GetNumberOfGrenades()
    {
        return numberOfGrenades;
    }
}
