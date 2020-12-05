using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private GameObject targets;

    public static int numberOfHits;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (numberOfHits == targets.transform.childCount)
        {
            Debug.Log("GAME OVER");
        }    
    }
}
