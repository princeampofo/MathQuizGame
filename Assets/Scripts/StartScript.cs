
//Calling necessary namespaces 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;              //Necessary for SceneManager
using UnityEngine.UI;

//Create class for start screen page of game
public class StartScript : MonoBehaviour
{
    //Function for clicking Level 1
    public void Level1Pressed()
    {
        SceneManager.LoadScene("Level1");               //Load level 1 scene
    }

    //Function for clicking level 2
    public void Level2Pressed()
    {
        SceneManager.LoadScene("Level2");           //Load level 2 scene
    }

    //Function for clicking level 3
    public void Level3Pressed()
    {
        SceneManager.LoadScene("Level3");               //Load level 3 scene
    }
}
