// Script for boss life and win condition
using UnityEngine;


public class BossDestroy : MonoBehaviour
{
    // Varaiables 
    public float hitsToDestroy;
    int hitCount = 0;
    float colorValue;
    Color color;

    void Start ()
    {
        color = gameObject.GetComponent<Renderer>().material.color; // get boss material color
    }

   
    void OnCollisionEnter(Collision collision)
    {
         // On collision with the player bullets
        if (collision.gameObject.name == "PlayerBulletSphere(Clone)")
        {
            // Count hits and change colour depending on how much hit points are left
            hitCount++;
            colorValue = 1f - (hitCount/hitsToDestroy);
            color.g = colorValue;
            gameObject.GetComponent<Renderer>().material.color = color;
            
        }
    }
    
    void Update (){
        // If hit count exceeds boss hitpoints load win screen
        if (hitCount >= hitsToDestroy)
        {
            GameManager.LoadWinScreen();
        }
    }
}
