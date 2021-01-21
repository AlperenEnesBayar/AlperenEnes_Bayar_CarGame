using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cars : MonoBehaviour
{
    Rigidbody2D rigidbodyCar; // Referance for car's rigidbody
    [SerializeField]
    private ParticleSystem exhaust;

    private float car_speed = 15f; // Car's frontal speed
    private float steering_speed = 1f; // Car's steering speed
    private bool isCrashed = false;
    private bool isDone = false;
    private RigidbodyConstraints2D originalConstraints; // For Pause|UnPause reasons 

    // Getters and Setters
    public float Car_speed { get => car_speed; set => car_speed = value; }
    public float Steering_speed { get => steering_speed; set => steering_speed = value; }
    public Rigidbody2D RigidbodyCar { get => rigidbodyCar; set => rigidbodyCar = value; }
    public bool IsCrashed { get => isCrashed; set => isCrashed = value; }
    public bool IsDone { get => isDone; set => isDone = value; }

    //Start
    void Start()
    {
        rigidbodyCar = GetComponent<Rigidbody2D>(); // Initialization for car's rigidbody
        originalConstraints = rigidbodyCar.constraints;
    }

    // If car reaches the exit
    public void ReachedExit()
    {
        isDone = true;
    }

    public void Crashed()
    {
        car_speed = 0f;
        steering_speed = 0f;
        isDone = true;
        isCrashed = true;
    }
    public void Restart()
    {
        car_speed = 15f;
        steering_speed = 1f;
        isDone = false;
        isCrashed = false;
    }

    public void Freeze()
    {
        rigidbodyCar.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
    }

    public void UnFreeze()
    {
        rigidbodyCar.constraints = originalConstraints;
    }

    public void FireExhaust()
    {
        exhaust.Play();
    }
}
