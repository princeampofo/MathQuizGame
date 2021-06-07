
//Calling necessary namespaces
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;


//Class for Level 3 scene
public class Level3 : MonoBehaviour
{
    public Text Questions;                          //Text Variable for saving Question
    public Text Answers;                            //Text Variable for saving Answer
    public Text Score;                              //Text Variable for saving game score

    public GameObject timing;                       //Gameobject Variable for checking time
    private float currentTime;                      //Variable for saving current time
    private float limitTime;                        //Variable for time limit
    private int Operator;                           //Variable for changing the mathemical operation

    private int Left;                               //Variable for Left integer of the question
    private int Right;                              //Variable for Right integer of the question
    private int CorrectAnswer;                      //Variable for the right answer
    private int WrongAnswer;                        //Variable for wrong answer
    private int YourScore;                          //Variable for saving gamescore
    private int i = 0;                              //Variable for counting number of questions displayed
    private int Totalques = 20;                     //Variable for total number of questions


    //When page is started
    public void Start()
    {
        currentTime = 0.0f;                         //Set time to zero
        limitTime = 10.0f;                          //Set time limit to 10

        YourScore = Level2.levelScore;              //Set game score to the final score of level 2
        SetQuestions();                             //Call function to display another question
    }

    //When game is running
    public void Update()
    {
        currentTime = currentTime + Time.deltaTime;                     //Update current time every second

        if (currentTime > limitTime)                                    //If current time exceeds the time limit
        {
            GameEnd();                              //End the game
        }
        else
        {
            //If time hasn't exceeded the limit count down the time to zero
            float ProgressTime = 1.0f - currentTime / limitTime;                    
            timing.transform.localScale = new Vector3(ProgressTime, 1, 1);
        }
    }


    //Function to set and display question
    public void SetQuestions()
    {
        Right = Random.Range(10, 30);                          //Set the right side of the question to a random between 10 and 30
        Left = Random.Range(-10, 20);                          //Set the left side of the question to a random between -10 and 20
        Operator = Random.Range(1, 4);                         //Set the operator of the question to a random between 1 and 4

        switch (Operator)
        {

            case 1:                                                     //If operator is 1
                 CorrectAnswer = Left * Right;                          //Multiply the integers on the left and right 
                 WrongAnswer = CorrectAnswer + Random.Range(-1, 1);     //Add a number between -1 and 1 to the correct answer and set it to the wrong answer        
                 Questions.GetComponent<Text>().text = Left.ToString() + "  *  " + Right.ToString() + "  =  ";          //Display the question
                break;                                                  //Break the switch


            case 2:                                                                     //If operator is 2
                CorrectAnswer = Left - Right;                                           //Subtract 
                WrongAnswer = CorrectAnswer + Random.Range(-1, 1);                      //Add a number between -1 and 1 to the correct answer and set it to the wrong answer
                Questions.GetComponent<Text>().text = Left.ToString() + "  -  " + Right.ToString() + "  =  ";               //Display the question
                break;                                                  //Break the switch


            case 3:                                                         //If operator is 3
                CorrectAnswer = Left + Right;                               //Add
                WrongAnswer = CorrectAnswer + Random.Range(-1, 1);          //Add a number between -1 and 1 to the correct answer and set it to the wrong answer
                Questions.GetComponent<Text>().text = Left.ToString() + "  +  " + Right.ToString() + "  =  ";                   //Display the question
                break;                                                       //Break the switch

            default:
                break;
        }
       
        Answers.GetComponent<Text>().text = WrongAnswer.ToString();                               //Display wrong answer
        Score.GetComponent<Text>().text ="Score:" + YourScore.ToString();                         //Display score
    }

  
    //WHen the true button is pressed
    public void CorrectButtonpressed()
    {
        if (CorrectAnswer == WrongAnswer)                                   //If the choice is right
        {
            currentTime = 0;                                                //Set time to zero
            YourScore += 1;                                                 //Increase score by one
            SetQuestions();                                                 //Call function to display another question
        }
        else
        {
            //If choice is wrong
            if (YourScore > 0)                                        //If score is greater than zero
            {
                YourScore -= 1;                                       //Decrease score by one
                SetQuestions();                                       //Call function to display another question
            }
            else
            {
                //If score is 0
                GameEnd();                                            //End the game
            }
        }

        ++i;                                                        //Increase the questions counter by one

        if (i == Totalques)                                         //If the questions have reached the total number of questions
        {
             GameEnd();                                             //End the game
        }
    }

    //Function for clicking false button
    public void FalseButtonIsPressed()
    {
        if (CorrectAnswer != WrongAnswer)                            //If the choice is right       
        {
            currentTime = 0;                                         //Set time to zero
            YourScore += 1;                                          //Increase score by one
            SetQuestions();                                          //Call function to display another question
        }
        else
        {
            //If choice is wrong
            if (YourScore > 0)                                        //If score is greater than zero
            {
                YourScore -= 1;                                         //Decrease score by one
                SetQuestions();                                         //Call function to display another question
            }
            else
            {
                //If score is 0
                GameEnd();                                          //End the game
            }
        }

        ++i;                                                        //Increase the questions counter by one

        if (i == Totalques)                                         //If the questions have reached the total number of questions
        {
            GameEnd();                                              //End the game
        }
    }

    
    //Function to end Game
    public void GameEnd()
    {
        Values.YourScore = YourScore;                                     //Save the score to Yourscore variable in Values script
        int Highscore = PlayerPrefs.GetInt("High_Score", 0);              //Set high score

        if (YourScore > Highscore)                                        //If game score is higher than high score
        {
            PlayerPrefs.SetInt("High_Score", YourScore);                   //Set High score to game score
        }
        SceneManager.LoadScene("MenuSpace");                               //Load Menu Scene
    }

}

