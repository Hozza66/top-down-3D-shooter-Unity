// Script for the 4 boss barriers and player upgrades
using UnityEngine;

public class BarrierDestroy : MonoBehaviour
{
    // Variables
    public Rigidbody prefab;

    // Spawn transforms for enemeies 
    public Transform spawnPoint1;
    public Transform spawnPoint2;
    public Transform spawnPoint3;
    public Transform spawnPoint4;
    public GameObject player;   // player object
    public float hitsToDestroy; // hits to destroy barrier 
    float hitCount = 0; // counter for hits
     int enemySpawnNumber;  // enemy spawn number

    // Shooting varaibles for player when each barrier is destoyed
    float fireRate;
    int bulletSpeed;
    bool secondFirePoint;

    bool playerthirdFirePoint;

   
    // color variables
    Color color;

    float transparency;
    
    void Start ()
    {
        color = gameObject.GetComponent<Renderer>().material.color; // get object colour
    }

    

    void OnCollisionEnter(Collision collision)
    {
        // On collision with player bullet
        if (collision.gameObject.name == "PlayerBulletSphere(Clone)")
        {   
            // count hits and change transparancy
            hitCount++;
            transparency = 1 - (hitCount/hitsToDestroy);
            color.a = transparency;
            gameObject.GetComponent<Renderer>().material.color = color;
        }

        // If hits is greater than hit points 
        if (hitCount > hitsToDestroy)
        {
            Destroy(gameObject);    // destroy barrier

            // Destroying each barrier gives the player a weapon upgrade
            // 1st barrier gives a extra firepoint/gun
            if (!secondFirePoint)
            {
                player.GetComponent<PlayerShooting>().secondFirePoint = true;
                enemySpawnNumber = 3;
            }else if (!playerthirdFirePoint)    // 2nd barrier gives another extra firepoint/gun
            {
                 player.GetComponent<PlayerShooting>().thirdFirePoint = true;
                 enemySpawnNumber = 6;
            }else if (fireRate != 0.1f)         // 3rd barrier increases player firerate
            {
                player.GetComponent<PlayerShooting>().fireRate = 0.1f;
                enemySpawnNumber = 9;
            }else if (bulletSpeed >= 50)        // 4th barrier increases player bullet speed
            {
                player.GetComponent<PlayerShooting>().bulletSpeed = 100;
                enemySpawnNumber = 12;
            }

            // Spawn enemy units after each barrier is destroyed, the number of spawns increases with each.
             for (int i = 0; i < enemySpawnNumber; i++){
                Rigidbody EnemyPrefab = Instantiate(prefab, spawnPoint1.position, spawnPoint1.rotation); 
            }

            for (int i = 0; i < enemySpawnNumber; i++){
                Rigidbody EnemyPrefab = Instantiate(prefab, spawnPoint2.position, spawnPoint2.rotation); 
            }

            for (int i = 0; i < enemySpawnNumber; i++){
                Rigidbody EnemyPrefab = Instantiate(prefab, spawnPoint3.position, spawnPoint3.rotation); 
            }

            for (int i = 0; i < enemySpawnNumber; i++){
                Rigidbody EnemyPrefab = Instantiate(prefab, spawnPoint4.position, spawnPoint4.rotation); 
            }
        }
    }

    // Update for player upgrades
    void Update()
    {
        secondFirePoint = player.GetComponent<PlayerShooting>().secondFirePoint;
        playerthirdFirePoint =  player.GetComponent<PlayerShooting>().thirdFirePoint;
        fireRate = player.GetComponent<PlayerShooting>().fireRate;
        bulletSpeed = player.GetComponent<PlayerShooting>().bulletSpeed;
    }
}
