using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private GameObject targets = null;
    [SerializeField]
    private Text youWinText = null;
    [SerializeField]
    private Text restartText = null;

    private bool gameOver = false;
    private float timeToRestart = 5.0f;

    public static int numberOfHits;

    private void Update()
    {
        if (numberOfHits == targets.transform.childCount)
        {
            youWinText.gameObject.SetActive(true);
            restartText.gameObject.SetActive(true);
            gameOver = true;
        }

        if (gameOver)
        {
            restartText.text = "Restart in: " + timeToRestart.ToString("F0");
            timeToRestart -= Time.deltaTime;
        }

        if (timeToRestart <= 0.0f)
        {
            numberOfHits = 0;
            SceneManager.LoadScene("GameScene");
        }
    }

    public bool GetGameOver()
    {
        return gameOver;
    }
}
