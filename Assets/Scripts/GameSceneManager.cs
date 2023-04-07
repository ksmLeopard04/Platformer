using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {

    }
    public void LoadMenu() => SceneManager.LoadScene(0);
    public void LoadLevelOne() => SceneManager.LoadScene(1);
    public void LoadLevelTwo() => SceneManager.LoadScene(2);
    public void Quit() => Application.Quit();
}
