// Script for enemy shooting
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    // Shooting variables 
    public Transform firePoint;     // fire point 
    public GameObject bulletPrefab; // bullet prefab
    public float bulletSpeed = 20;  // bullet speed

    public float fireRate = 0.5f;   // fire rate
    float nextShotTime = 0;     // next shot time

    public bool toggleShoot = false;    // shooting toggle

    // Update is called once per frame
    void Update()
    {   
        if (toggleShoot){shoot();}  // shoot when toggled
    }

    // Shoot function
    void shoot (){
        // only shoot when time reached
        if (nextShotTime < Time.time) 
        {
            nextShotTime = fireRate + Time.time;    // set next shot time

            // Create bullet object from prefab at fire point with rigidbody, force, speed, rotation
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
            bulletRigidbody.AddForce(firePoint.forward * bulletSpeed, ForceMode.Impulse);
        }
    }
}
