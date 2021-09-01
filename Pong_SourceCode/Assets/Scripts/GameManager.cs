using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Ball")]
    public GameObject ball;

    [Header("Player 1")]
    public GameObject Player1Paddle;

    public GameObject Player1Goal;

    [Header("Player 2")]
    public GameObject Player2Paddle;

    public GameObject Player2Goal;

    [Header("Pause Menu")]
    public bool gamePaused = false;

    public GameObject pauseMenu;

    [Header("BC Wall")]
    public GameObject BCWall;

    [Header("Score UI")]
    public GameObject Player1Text;

    public GameObject Player2Text;

    [Header("Help Text")]
    public GameObject HelpText;
    public GameObject LaunchText;

    private int Player1Score;

    private int Player2Score;

    public static int GameMode;

    public void Player1Scored()
    {
        Player1Score++;
        Player1Text.GetComponent<TextMeshProUGUI>().text =
            Player1Score.ToString();
        ResetPosition();
    }

    public void Player2Scored()
    {
        Player2Score++;
        Player2Text.GetComponent<TextMeshProUGUI>().text =
            Player2Score.ToString();
        ResetPosition();
    }

    private void ResetPosition()
    {
        ball.GetComponent<Ball>().Reset();
        Player1Paddle.GetComponent<Paddle>().Reset();
        Player2Paddle.GetComponent<Paddle>().Reset();
    }

    void Start()
    {
        switch (GameMode)
        {
            case 1:
                Time.timeScale = 1;
                BCWall.SetActive(false);
                break;
            case 2:
                Time.timeScale = 2;
                BCWall.SetActive(false);
                break;
            case 3:
                Time.timeScale = 3;
                BCWall.SetActive(true);
                break;
            default:
                Time.timeScale = 1;
                BCWall.SetActive(false);
                break;
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (!gamePaused)
            {
                Time.timeScale = 0;
                gamePaused = true;
                Cursor.visible = true;
                pauseMenu.SetActive(true);
            }
            else
            {
                pauseMenu.SetActive(false);
                Cursor.visible = false;
                gamePaused = false;
                Time.timeScale = 1;
            }
        }
        if (Input.GetButtonDown("Quit"))
        {
            if (gamePaused)
            {
                Time.timeScale = 1;
                SceneManager.LoadScene("MainMenu");
            }
        }
        if (Input.GetButtonDown("Launch"))
        {
            HelpText.SetActive(false);
            LaunchText.SetActive(false);
        }
    }
}
