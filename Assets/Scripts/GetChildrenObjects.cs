// Script to controll a group of child componets
using UnityEngine;

public class GetChildrenObjects : MonoBehaviour
{
    // Toggle for if the goal is hit by player
    public bool hitByPlayer = false;

    // Update is called once per frame
    void Update()
    {
        // If the player hits the goal all enemy object of that goal will start engaging the player
        if (hitByPlayer)
        {
            // Loop through each enemy child and toggle there hit by player function from EnemyMovemnt script
            foreach (Transform child in transform){
                child.GetComponent<EnemyMovement>().hitByPlayer = true;
            }
        }
            
    }
}
