using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsHolder : MonoBehaviour
{
    private int selectedWeapon = 0;

    private void Start()
    {
        SelectWeapon();
    }

    private void Update()
    {
        ChangingWeapon();
    }

    private void SelectWeapon()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (i == selectedWeapon)
            {
                transform.GetChild(i).gameObject.SetActive(true);
            }
            else
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }

    private void ChangingWeapon()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            selectedWeapon++;
            if (selectedWeapon > transform.childCount - 1)
            {
                selectedWeapon = 0;
            }
            SelectWeapon();
        }
    }
}
