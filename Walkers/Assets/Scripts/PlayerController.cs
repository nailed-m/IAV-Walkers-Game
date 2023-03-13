using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * Class: PlayerController
 * Its purpose is to define the behaviour of the player's movement, which will be controlled by using the arrows from user's keyboard (DONE)
 * It also has to manage its collisions with ally minions, enemy minions, enemy player and the scenario using Rigidbody or Colliders in each case (TO-DO)
 */

public class PlayerController : MonoBehaviour
{
    /*
     * Public Variables
     * Speed: player's movement speed
     * HP: Health points
     */
    public float speed;
    public int hp;

    /*
     * Private Variables
     * rb: RigidBody component thta manage collisions with other objects so that it does not pass through them
     */
    private Rigidbody rb;

    //Method that is launched whe an instance of this class is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    //This method is called every frame to update what is seen in the gameplay
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(-moveVertical, 0.0f, moveHorizontal);
        rb.AddForce(movement * speed);
    }

    /**
     * This method manages what happens when the player's collider enters in other's collider
     * If player collides with an enemy minion, it has to lose one health point
     * If player collides with other objetct, nothing special happens
     */
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("EnemyMinion"))
        {
            hp--;
            if (hp == 0)
            {
                //To-Do: You Lose
            }
        }
    }
}
