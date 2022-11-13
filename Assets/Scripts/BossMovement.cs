// Script for boss movement
using UnityEngine;


public class BossMovement : MonoBehaviour
{
    public Transform boss;
    public float rotationSpeed; // public rotation speed variable


    // The rotates the boss according to rotation speed
    void Update()
    {
        transform.Rotate(0,rotationSpeed*Time.deltaTime,0, Space.Self);
    }
}
