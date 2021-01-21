using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class car_movement : MonoBehaviour
{
    [SerializeField]
    Cars car; // Car's main class's script
    float total_steering, direction; // Values for calculating direction vector


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
        car.RigidbodyCar.AddRelativeForce(Vector2.up * car.Car_speed);

        // Right and left steering with mouse click or touch screens
        direction = Mathf.Sign(Vector2.Dot(car.RigidbodyCar.velocity, car.RigidbodyCar.GetRelativeVector(Vector2.up)));

        if (Input.GetMouseButton(0))
        {
            float middle = Screen.width / 2;
            if(Input.mousePosition.x < middle)
            {
                total_steering = 1;
            }
            else
            {
                total_steering = -1;              
            }
            car.FireExhaust();
            car.RigidbodyCar.rotation += total_steering * car.Steering_speed * car.RigidbodyCar.velocity.magnitude * direction;
            car.RigidbodyCar.AddRelativeForce(-Vector2.right * car.RigidbodyCar.velocity.magnitude * total_steering / 2);     
        }      
    }
}
