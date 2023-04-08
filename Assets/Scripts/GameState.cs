using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public float startTime;
    public float fastestTime;
    public float endTime;
    public float elapsedTime;
    public static string message;
    // Start is called before the first frame update
    void Awake()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("GameState");
        if (objects.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime = Time.time - startTime;
        if (GameSceneManager.gameOver == true && PlayerController.timeRecorded == false)
        {
            endTime = elapsedTime;
            PlayerController.timeRecorded = true;
        }
        if(endTime < fastestTime || fastestTime == 0)
        {
            fastestTime = endTime;
        }
        message = $"GAME OVER!\nFastest Time: {fastestTime} seconds\nYour Time: {endTime} seconds";
    }
}
