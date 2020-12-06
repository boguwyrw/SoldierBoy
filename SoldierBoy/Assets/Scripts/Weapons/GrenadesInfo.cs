using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrenadesInfo : MonoBehaviour
{
    [SerializeField]
    private GameObject grenade = null;
    [SerializeField]
    private Text grenadesInfoText = null;

    private GrenadeParameters grenadeParameters;
    private int gremadesNumber = 3;

    private void Start()
    {
        grenadeParameters = grenade.GetComponent<GrenadeParameters>();
        
    }

    private void Update()
    {
        if (grenade.activeSelf)
        {
            gremadesNumber = grenadeParameters.GetNumberOfGrenades();
            if (gremadesNumber == 0)
                grenadesInfoText.gameObject.SetActive(true);
        }
        else
        {
            grenadesInfoText.gameObject.SetActive(false);
        }
    }
}
