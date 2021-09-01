using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void ExitButton() {
        Application.Quit();
        Debug.Log("Game closed");
    }

    public void StartGame_Pong() {
        GameManager.GameMode = 1;
        SceneManager.LoadScene("Game");
    }

    public void StartGame_Speedpong() {
        GameManager.GameMode = 2;
        SceneManager.LoadScene("Game");
    }

    public void StartGame_BCMode() {
        GameManager.GameMode = 3;
        SceneManager.LoadScene("Game");
    }

    void Update(){
        if (Input.GetButtonDown("Cancel"))
        {
            Debug.Log("Quitting Game");
            Application.Quit();
        }
    }
}
