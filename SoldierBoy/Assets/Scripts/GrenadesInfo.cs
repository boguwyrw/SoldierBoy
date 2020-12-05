using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrenadesInfo : MonoBehaviour
{
    [SerializeField]
    private GameObject grenade;
    [SerializeField]
    private Text grenadesInfoText;

    private GrenadeParameters grenadeParameters;

    private void Start()
    {
        grenadeParameters = grenade.GetComponent<GrenadeParameters>();
        
    }

    private void Update()
    {
        if (grenade.activeSelf)
        {
            if (grenadeParameters.GetNumberOfGrenades() == 0)
                grenadesInfoText.gameObject.SetActive(true);
        }
        else
        {
            grenadesInfoText.gameObject.SetActive(false);
        }
    }
}
