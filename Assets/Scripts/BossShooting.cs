// Script for boss shooting
using UnityEngine;

public class BossShooting : MonoBehaviour
{   

    // Variables for the 4 fire points the boss has
    public Transform firePoint1;
    public Transform firePoint2;
    public Transform firePoint3;
    public Transform firePoint4;

    // Boss shooting variables
    public GameObject bulletPrefab;
    public float bulletSpeed = 20;
    public float fireRate = 0.5f;
    float nextShotTime = 0;
    public bool toggleShoot = false;

    // Shooting function
    void shoot (){

        // Shoot when next shoot timer is meet
        if (nextShotTime < Time.time)   
        {
            // Create bullet prefab on each fire point and initiate rigidbody with force, speed and direction.
            nextShotTime = fireRate + Time.time;
            GameObject bullet = Instantiate(bulletPrefab, firePoint1.position, firePoint1.rotation);
            Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
            bulletRigidbody.AddForce(firePoint1.forward * bulletSpeed, ForceMode.Impulse);

            bullet = Instantiate(bulletPrefab, firePoint2.position, firePoint2.rotation);
            bulletRigidbody = bullet.GetComponent<Rigidbody>();
            bulletRigidbody.AddForce(firePoint2.forward * bulletSpeed, ForceMode.Impulse);

            bullet = Instantiate(bulletPrefab, firePoint3.position, firePoint3.rotation);
            bulletRigidbody = bullet.GetComponent<Rigidbody>();
            bulletRigidbody.AddForce(firePoint3.forward * bulletSpeed, ForceMode.Impulse);

            bullet = Instantiate(bulletPrefab, firePoint4.position, firePoint4.rotation);
            bulletRigidbody = bullet.GetComponent<Rigidbody>();
            bulletRigidbody.AddForce(firePoint4.forward * bulletSpeed, ForceMode.Impulse);
        }
    }

     // Call shoot function
    void Update()
    {
        shoot();
    }
}
