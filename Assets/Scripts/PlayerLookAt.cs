// Script for the player object to look at mouse
using UnityEngine;

public class PlayerLookAt : MonoBehaviour
{
    void Update()
    {
        // Cast ray from camera to mouse point
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane rayPlane = new Plane(Vector3.up, Vector3.zero);       // create plane 
        float rayOut;

        if (rayPlane.Raycast(ray, out rayOut))
        {
            // Get the vector where the ray cast hits the plane and return it, only x and z coordinates are used 
            Vector3 lookAtVector = new Vector3(ray.GetPoint(rayOut).x, transform.position.y, ray.GetPoint(rayOut).z);

            // Rotate the palyer object to face the loot at vector
            transform.LookAt(lookAtVector); 
        }
    }

}
