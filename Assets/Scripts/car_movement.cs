using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class car_movement : MonoBehaviour
{
    Rigidbody2D rigidbodyCar; // Referance for car's rigidbody

    [SerializeField]
    float car_speed = 15f; // Car's frontal speed
    [SerializeField]
    float steering_speed = 1f; // Car's steering speed
    float total_steering, direction; // Values for calculating direction vector





    void Start()
    {
        rigidbodyCar = GetComponent<Rigidbody2D>(); // Initialization for car's rigidbody
    }

    /* I'm using FixedUpdate() instead of Update() method for car movement, because: 
     *
     * "It's for this reason that FixedUpdate should be used when applying forces,
     * torques, or other physics-related functions - because you know it will 
     * be executed exactly in sync with the physics engine itself."
     * 
     * - From Unity Forms (https://answers.unity.com/questions/10993/whats-the-difference-between-update-and-fixedupdat.html)
     * 
    */
    void FixedUpdate()
    {
        // Automatic drives front direction
        rigidbodyCar.AddRelativeForce(Vector2.up * car_speed);

        // Right and left steering
        direction = Mathf.Sign(Vector2.Dot(rigidbodyCar.velocity, rigidbodyCar.GetRelativeVector(Vector2.up)));
        total_steering = -Input.GetAxis("Horizontal");
        rigidbodyCar.rotation += total_steering * steering_speed * rigidbodyCar.velocity.magnitude * direction;
        rigidbodyCar.AddRelativeForce(-Vector2.right * rigidbodyCar.velocity.magnitude * total_steering / 2);

    }
}
