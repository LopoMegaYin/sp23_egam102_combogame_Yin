using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RandomNumGenerator : MonoBehaviour
{
    public int randomNumber;
    public int highScore;

    public TextMeshProUGUI scoreDisplay;
    public TextMeshProUGUI highScoreDisplay;
    public TextMeshProUGUI finalscoreDisplay;
    public TextMeshProUGUI finalhighScoreDisplay;

    // Start is called before the first frame update
    void Start()
    {
        //get the play pref hs value!
        highScore = PlayerPrefs.GetInt("High Score", 0);
        //
        highScoreDisplay.text = highScore.ToString();
    }

    //public void PickARandomNumber ()
    //{
        //Pick Random #
        //randomNumber = Random.Range(0, 100);
        //Show that #
        // scoreDisplay.text = randomNumber.ToString();
        //Check if it is a high score!
        //CheckForHighScore();
    //}

    void Update()
    {
        scoreDisplay.text = randomNumber.ToString();
        finalscoreDisplay.text = randomNumber.ToString();
        finalhighScoreDisplay.text = highScore.ToString();
        if (randomNumber > highScore)
        {
            //Set high score to random number!
            highScore = randomNumber;
            //Set HS
            PlayerPrefs.SetInt("High Score", highScore);
            //Display new HS
            highScoreDisplay.text = highScore.ToString();
            
        }

        if (Input.GetKey(KeyCode.T))
        {
            PlayerPrefs.DeleteAll();
        }
        //CheckForHighScore();
    }

    //public void CheckForHighScore ()
    //{
        //if (randomNumber > highScore)
        //{
            //Set high score to random number!
            //highScore = randomNumber;
            //Set HS
            //PlayerPrefs.SetInt("High Score", highScore);
            //Display new HS
            //highScoreDisplay.text = highScore.ToString();
            //finalhighScoreDisplay.text = highScore.ToString();
        //}
    //}
}
