// Script for normal enemy movement
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{   

    // Using navMesh
    NavMeshAgent agent;
    Transform player;
    public EnemyShooting EnemyShootingScript; // referencing shooting script
    public Transform[] waypoints;   // way points array
    public float detectDistance;    // distance to engage player
    public float disengageDistance; // distance disengage player
    public float shootDistance;     // distance to shoot at player
    
    // Bool toggles
    bool playerInRange = false;  
    public bool hitByPlayer = false;


    float distanceToPlayer;     // distance between enemy object and player
    float distanceToWaypoint;   // distance to waypoints
    Vector3 startPosition;      
    int waypointIndex;      
    int numberWaypoints = 9;

    // Assign variables to objects and transforms
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("PlayerSquare").transform;
        startPosition = transform.position;
        waypointIndex = Random.Range(0,numberWaypoints);
    }

    // On collision with player bullet, toggle 
    void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.name == "PlayerBulletSphere(Clone)")
            {
                hitByPlayer = true;
            }
        }

    // Function to chase player
    void chasePlayer ()
    {
        agent.destination = player.position;
    }

    // Fucntion to patrol way points
    void patrolWaypoints() {

        agent.destination = waypoints[waypointIndex].position;  // go to way point

        // Chose next waypoint randomly 
        if (distanceToWaypoint < 1){
            waypointIndex = Random.Range(0,numberWaypoints);
        }
    }
    
    void Update()
    {
        distanceToPlayer = Vector3.Distance(player.position, transform.position);   // calculates distance to player transform
        
        distanceToWaypoint = Vector3.Distance(waypoints[waypointIndex].position, transform.position);   // calculate distance from waypoints
        
        // Toggle if play is in range
        if (distanceToPlayer < detectDistance || hitByPlayer) 
        {
            playerInRange = true;
        }

        // Toggle if palyer is far away enouhg to disengage
        if (distanceToPlayer > disengageDistance && playerInRange && !hitByPlayer) { playerInRange = false;}

        // Chase palyer if in range
        if (playerInRange) {chasePlayer();}  

        // Patrol waypoints if player not in range
        if (!playerInRange) {patrolWaypoints();}

        // Shoot at player if in range
        if (distanceToPlayer < shootDistance) {EnemyShootingScript.toggleShoot = true;}

        // Stop shooting if player out of range
        if (distanceToPlayer > shootDistance) {EnemyShootingScript.toggleShoot = false;}

    }

}
