// Script to destory enemy units
using UnityEngine;

public class EnemyDestroy : MonoBehaviour
{
    // Variables for hit points and counts
    public float hitsToDestroy;
    int hitCount = 0;

    // Colour variables
    float colorValue;
    Color color;
    void Start ()
    {
        color = gameObject.GetComponent<Renderer>().material.color; // get object color
    }
    void OnCollisionEnter(Collision collision)
    {
        // On collision with player bullet
        if (collision.gameObject.name == "PlayerBulletSphere(Clone)")
        {
            // Count hits and change colour relative to how many hits taken
            hitCount++;
            colorValue = 0.8f - (hitCount/hitsToDestroy);
            color.g = colorValue;
            gameObject.GetComponent<Renderer>().material.color = color;

            
            // If hits is greater than hit points destroy object.
            if (hitCount >= hitsToDestroy)
            {
                Destroy(gameObject);
            }
        }
    }    
}
