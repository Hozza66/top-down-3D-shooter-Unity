// Script for the player's shooting mechanic
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    // Player fire points
    public Transform firePoint;
    public Transform firePoint2;
    public Transform firePoint3;

    // Shooting varaibles
    public GameObject bulletPrefab; // bullet prefab
    public int bulletSpeed = 20;    // bullet speed

    public float fireRate = 0.5f;   // bullet fire rate 
    public bool secondFirePoint = false;    // second gun toggle
    public bool thirdFirePoint = false; // third gun toggle
    float nextShotTime = 0;     // next shot time
    
    // Shooting function
    void shoot (){

        // If mouse button is pressed and next shot time reached
        if (Input.GetKey(KeyCode.Mouse0) && nextShotTime < Time.time) 
        {
            // Reset new next shot time
            nextShotTime = fireRate + Time.time;

            // Create a bullet prefab object at fire point with rigidbody, transfoprm and forces
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
            bulletRigidbody.AddForce(firePoint.forward * bulletSpeed, ForceMode.Impulse);

            // Fire second gun if toggle is enabled
            if (secondFirePoint)
            {
                bullet = Instantiate(bulletPrefab, firePoint2.position, firePoint2.rotation);
                bulletRigidbody = bullet.GetComponent<Rigidbody>();
                bulletRigidbody.AddForce(firePoint2.forward * bulletSpeed, ForceMode.Impulse); 
            }

            // Fire third gun if toggle is enabled
            if (thirdFirePoint)
            {
                bullet = Instantiate(bulletPrefab, firePoint3.position, firePoint3.rotation);
                bulletRigidbody = bullet.GetComponent<Rigidbody>();
                bulletRigidbody.AddForce(firePoint3.forward * bulletSpeed, ForceMode.Impulse); 
            }
        }
    }
    
    // Update is called once per frame
    void Update()
    {   
        shoot();
    }
}
