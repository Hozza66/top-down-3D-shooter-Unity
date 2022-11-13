// Static script for game managment
using UnityEngine.SceneManagement;

public static class GameManager
{

    static int goalsDestroyed = 0;  // varaible for goals destroyed

    // function to load level 1
    static public void LoadLevel1(){
        SceneManager.LoadScene("Level1");
        GameTimer.startTimer();             // start game timer
    }

    // function to load level 2
    static public void LoadLevel2(){
        SceneManager.LoadScene("Level2");
    }

    // function to load death screen
    static public void LoadDeathScreen(){
        SceneManager.LoadScene("DeathScreen");
    }

    // function to win screen
    static public void LoadWinScreen(){
        SceneManager.LoadScene("WinScreen");
    }

    // function to load how to screen
    static public void LoadHowTo(){
        SceneManager.LoadScene("HowToScreen");
    }

    // function to menu screen
    static public void LoadMenu(){
        SceneManager.LoadScene("MenuScreen");
    }

    // function to count goals destroyed in level 1
    static public void GoalDestroyed()
    {
        goalsDestroyed++;

        // If both goals destroyed load level 2
        if (goalsDestroyed > 1) 
        {
            LoadLevel2();
        }
    }
}
