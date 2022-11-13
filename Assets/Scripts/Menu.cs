// Script for menu options
using UnityEngine;

public class Menu : MonoBehaviour
{
    // Function for starting the game, load level 1 and start timer
    public void startGame(){
        //GameManager.Instance.LoadLevel1();
        GameTimer.startTimer();
        GameManager.LoadLevel1();
    }
    
    // Function to access how to play
    public void howTo(){
        GameManager.LoadHowTo();
    }

    // Function to quit game
    public void quitGame(){
        Application.Quit();
    }
    
}
