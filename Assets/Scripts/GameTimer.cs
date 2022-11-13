// Static class for game timer
using UnityEngine;

public static class GameTimer 
{
    // Varables for start and end time
    static float startTime;
    static float timeElapsed;

    // Function to start the timer
    static public void startTimer()
    {
         startTime = Time.time;
    }

    // Function to stop timer and return total time played
    static public float endTimer()
    {
        timeElapsed = Time.time - startTime;
        return timeElapsed;
    }
}
