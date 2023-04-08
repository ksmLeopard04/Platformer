using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Text = TMPro.TMP_Text;

public class Button : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (GameSceneManager.gameOver == true)
        {
            GameObject.Find("Play").GetComponentInChildren<Text>().text = "RESTART";
        }
        else
        {
            GameObject.Find("Play").GetComponentInChildren<Text>().text = "PLAY";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
