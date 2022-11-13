// Script for Goal objects
using UnityEngine;

public class GoalDestroy : MonoBehaviour
{
    // Varaibales
    public GetChildrenObjects GetChildrenObjectsScript; // child objects
    public float hitsToDestroy; // hit points
    float hitCount = 0;     // hit counter

    // Colour variables
    float goalTransparency;
    Color color;

    void Start ()
    {
        color = gameObject.GetComponent<Renderer>().material.color; // get object colour
    }

    void OnCollisionEnter(Collision collision)
    {   
        // On collision with player bullet toggle all child objects to engage player
        if (collision.gameObject.name == "PlayerBulletSphere(Clone)")
        {   
            GetChildrenObjectsScript.hitByPlayer = true;

            // Count hit and change transparancy relative to hit points
            hitCount++; 
            goalTransparency = 1 - (hitCount/hitsToDestroy);
            color.a = goalTransparency;
            gameObject.GetComponent<Renderer>().material.color = color;
        }

        // Destroy goal object and count it in GameManager
        if (hitCount == hitsToDestroy)
        {
            Destroy(gameObject);
            GameManager.GoalDestroyed();
        }
    }
}
