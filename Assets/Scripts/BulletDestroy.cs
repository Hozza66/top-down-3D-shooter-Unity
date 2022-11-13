// Script for destroying any bullet oncollision
using UnityEngine;

public class BulletDestroy : MonoBehaviour
{   
    // Destroy bullet on collision
    void OnCollisionEnter(Collision collision)
    {
             Destroy(gameObject);   
    }  
}
