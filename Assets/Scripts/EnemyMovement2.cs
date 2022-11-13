// Script for enemy movemnts spawned by boss
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement2 : MonoBehaviour
{
    //Object varables 
    NavMeshAgent agent;
    Transform player;

    // Shooting varables
    public EnemyShooting EnemyShootingScript;
    public float shootDistance;
    float distanceToPlayer;




    // Setup objects
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("PlayerSquare").transform;
    }
    
    void Update()
    {
        // Chase player and shoot when in range
        chasePlayer();
        distanceToPlayer = Vector3.Distance(player.position, transform.position);
        if (distanceToPlayer < shootDistance) {EnemyShootingScript.toggleShoot = true;}
    }

    // Chase function
    void chasePlayer ()
    {
        agent.destination = player.position;
    }
}
