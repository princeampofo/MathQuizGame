
//Calling necessary namespaces 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;                      //Necessary for SceneManager
using UnityEngine.UI;


//Class for Menu page
public class PlayAgainScript : MonoBehaviour
{
    public Text Scoretext;                          //Variable for saving gamescore
    public Text HighScore;                          //Variable for saving highscore


    //When page is called
    public void Start()
    {
        Scoretext.GetComponent<Text>().text = "Score: " + Values.YourScore.ToString();                         //Print game score to the screen 
        HighScore.GetComponent<Text>().text = "High Score: " + PlayerPrefs.GetInt("High_Score", 0).ToString();      //Print high score to the screen
    }

    //When play again button is clicked
    public void PlayButtonClicked()
    {
        SceneManager.LoadScene("Level1");                       //Load level 1 scene
    }

    //When menu button is clicked 
    public void MenuButtonClicked()
    {
        SceneManager.LoadScene("StartScene");                   //Load Start screen
    }
}
