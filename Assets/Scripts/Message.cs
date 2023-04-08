using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using Text = TMPro.TMP_Text;

public class Message : MonoBehaviour
{
    private Text displayText;
    string message;

    // Start is called before the first frame update
    void Start()
    {
        displayText = GetComponent<Text>();
        if(GameSceneManager.gameOver == false)
        {
            message = "Welcome to Day And Knight, a minimalist platformer game where you'll take control of a lone adventurer and journey through a series of levels. With no enemies or obstacles to hold you back, your only goal is to run, jump, and explore your way to the end of each level. With intuitive controls, and smooth gameplay, Day And Knight offers a simple yet engaging platforming experience that's perfect for a quick gaming session or a peaceful moment of escape. So get ready to take on the challenge and see how fast you can go!";
        }
        else
        {
            message = GameState.message;
        }
    }

    // Update is called once per frame
    void Update()
    {
        displayText.text = message;
    }
}
