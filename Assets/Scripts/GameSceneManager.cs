using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    public static bool gameOver = false;
    // Start is called before the first frame update
    private void Start()
    {

    }
    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
        GameSaveManager.gameStarted = false;
        PlayerController.timeRecorded = false;
    }
    public void LoadLevelOne()
    {
        GameSceneManager.gameOver = false;
        GameSaveManager.gameStarted=true;
        SceneManager.LoadScene(1);
    }
    public void LoadLevelTwo()
    {
        GameSaveManager.gameStarted=false;
        SceneManager.LoadScene(2);
    }
    public void Quit() => Application.Quit();
}
