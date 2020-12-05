using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private GameObject targets;
    [SerializeField]
    private Text youWinText;

    private bool gameOver = false;
    private float timeToRestart = 5.0f;

    public static int numberOfHits;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (numberOfHits == targets.transform.childCount)
        {
            youWinText.gameObject.SetActive(true);
            gameOver = true;
        }

        if (gameOver)
        {
            timeToRestart -= Time.deltaTime;
        }

        if (timeToRestart <= 0.0f)
        {
            numberOfHits = 0;
            SceneManager.LoadScene("GameScene");
        }
    }
}
