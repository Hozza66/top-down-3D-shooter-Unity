// Script for win screen
using UnityEngine;
using UnityEngine.UI;

public class WinScreen : MonoBehaviour
{   
    // Win screen Panel text variable
    public Text timerText;

    public void Start()
    {
        // Call GamETimer for total play time
        float time = GameTimer.endTimer();

        float minutes = Mathf.FloorToInt(time/60);
        float seconds = Mathf.FloorToInt(time%60);

        // Display total paly time on the win screen panel
        timerText.text = "Game completed in: " + minutes + "m" + seconds + 's';
    }

}
