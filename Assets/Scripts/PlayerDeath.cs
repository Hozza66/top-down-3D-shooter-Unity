// Script for Player life and death functions.
using UnityEngine;
public class PlayerDeath : MonoBehaviour
{
    // Variables
    int hitCount = 0;   // hit counter
    public float life;  // life set varabile

    Color color;        

    float transparency; // for transparancy value

    float nextFlashTime = 0;    // for material flashing timer 
    bool toggle = false;    

    void Start ()
    {
        color = gameObject.GetComponent<Renderer>().material.color; // get object material
    }

    // On collision with enemy bullet
    void OnCollisionEnter(Collision collision)
    {
        // Count each hit
        if (collision.gameObject.name == "EnemyBulletSphere(Clone)" || collision.gameObject.name == "BossBulletSphere(Clone)" )
        {
            hitCount++;
        }

        
        // If hit number equals life then load death screen
        if (hitCount >= life) 
        {
             GameManager.LoadDeathScreen();
        }
    }


    void Update()
    {
        playerFlashing();
    }

    // Function to flash player
    void playerFlashing(){
        // Flash when player on last life with flash timing
        if (hitCount == life-1 && nextFlashTime < Time.time)
        {
            nextFlashTime = 0.2f + Time.time; // set next flash time
            
            // Toggle transparency to emulate flashing
            if (!toggle){
                color.a = 0.1f;
                gameObject.GetComponent<Renderer>().material.color = color;
                Debug.Log("T1 " + gameObject.GetComponent<Renderer>().material.color);
                toggle = true;
                
            }else
            {
                color.a = 1f;
                gameObject.GetComponent<Renderer>().material.color = color;
                 Debug.Log("T2 " + gameObject.GetComponent<Renderer>().material.color);
                toggle = false;
            }
        }
    }
}
