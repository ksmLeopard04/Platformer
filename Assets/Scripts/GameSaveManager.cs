using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameSaveManager : MonoBehaviour
{
    protected GameState gameState;
    string desiredPath;
    public static bool gameStarted;
    void Awake()
    {
        desiredPath = Path.Combine(Application.persistentDataPath, "Platformer_Fastest.txt");
    }
    // Start is called before the first frame update
    private void Start()
    {
        gameState = GameObject.FindObjectOfType<GameState>();
        LoadFromDisk();
        if (gameStarted)
        {
            gameState.startTime = Time.time;
        }
    }
    public void LoadFromDisk()
    {
        if (File.Exists(desiredPath))
        {
            using (StreamReader streamReader = File.OpenText(desiredPath))
            {
                string jsonString = streamReader.ReadToEnd();
                JsonUtility.FromJsonOverwrite(jsonString, gameState);
            }
        }
    }

    public void SaveToDisk()
    {
        string jsonString = JsonUtility.ToJson(gameState);
        using (StreamWriter streamWriter = File.CreateText(desiredPath))
        {
            streamWriter.Write(jsonString);
        }
    }
    // Update is called once per frame
    void Update()
    {
        SaveToDisk();
    }
}
