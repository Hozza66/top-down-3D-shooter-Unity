// Script for player movements
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Variables
    public float movementSpeed;   // Movement speed
    public float dashSpeed;     // dash speed
    public float dashCooldownTime;  // dash cool down time
    public float dashLength;    // dash length
    float dashTimer;        // dash timer
    float nextDashTime = 0; // next dash time
    bool dashToggle = false;    // dash toggle
    Rigidbody playerRigidbody;  // Rigidbody variable
    Vector3 movementInput;      // Vector3 variable to store input vectors
    Color color;    // color variable

    void Start()
    {
        // Getting rigidbody and color component
        playerRigidbody = GetComponent<Rigidbody>(); 
        color = gameObject.GetComponent<Renderer>().material.color;
    }

    void Update()
    {   
        // Store the x and z inputs in a Vector3 variable, y axis input is not needed so set as 0 
        movementInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        // move and dash call
        move();
        dash();
    }

    void move(){
        // move normally if dash is not toggled
        if (!dashToggle)
        {
            playerRigidbody.velocity = movementInput * movementSpeed;
        }

        // If dash is toggled and the time for dash cool down is reached, dash with faster movemnt speed
       
        if (dashToggle && (Time.time-dashTimer < dashLength) )
        { 
            playerRigidbody.velocity = movementInput * dashSpeed;
        } else {
            playerRigidbody.velocity = movementInput * movementSpeed;    // return to normal speed after dashing
        }
       
    }

    // Dash function
    void dash ()
    {
        // Toggle if space bar is pressed and cooldown is finished
        if (Input.GetKeyDown("space") && nextDashTime < Time.time)
        {
            dashTimer = Time.time;  // timer
            nextDashTime = dashCooldownTime + Time.time;    // next dash time
            dashToggle = true;
        } else if (nextDashTime < Time.time)    // toggle off if cooldown have not finished
        {
            dashToggle= false;
        }
    }
}
