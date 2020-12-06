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
    private Text outOfRangeText = null;
    [SerializeField]
    private Text restartText = null;

    private bool gameOver = false;
    private float timeToRestart = 5.0f;

    public static int numberOfHits;

    private void Start()
    {
        Cursor.visible = false;
    }

    private void Update()
    {
        GameOverRestartSystem();
        ExitGame();
    }

    private void GameOverRestartSystem()
    {
        if (numberOfHits == targets.transform.childCount)
        {
            youWinText.gameObject.SetActive(true);
            gameOver = true;
        }

        if (gameOver)
        {
            restartText.gameObject.SetActive(true);
            restartText.text = "Restart in: " + timeToRestart.ToString("F0");
            timeToRestart -= Time.deltaTime;
        }

        if (timeToRestart <= 0.0f)
        {
            numberOfHits = 0;
            SceneManager.LoadScene("GameScene");
        }
    }

    private void ExitGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            outOfRangeText.gameObject.SetActive(true);
            gameOver = true;
        }
    }

    public bool GetGameOver()
    {
        return gameOver;
    }
}
