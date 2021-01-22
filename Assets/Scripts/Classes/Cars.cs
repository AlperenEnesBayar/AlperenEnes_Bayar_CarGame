using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cars : MonoBehaviour
{
    Rigidbody2D rigidbodyCar; // Referance for car's rigidbody
    [SerializeField]
    private ParticleSystem exhaust;
    

    public float starting_car_speed = 15f; // Car's frontal speed
    public float starting_steering_speed = 1f; // Car's steering speed

    private float car_speed; 
    private float steering_speed; 
    private bool isCrashed = false;
    private bool isDone = false;
    private bool isNPC;
    private RigidbodyConstraints2D originalConstraints; // For Pause|UnPause reasons

    private List<Vector3> savedPositions;
    private List<Quaternion> savedRotations;
    private int savedTime = 0;

    private Vector3 snapPosition;
    private Quaternion snapRotation;

    // Getters and Setters
    public float Starting_car_speed { get => starting_car_speed; set => starting_car_speed = value; }
    public float Starting_steering_speed { get => starting_steering_speed; set => starting_steering_speed = value; }
    public float Car_speed { get => car_speed; set => car_speed = value; }
    public float Streering_speed { get => steering_speed; set => steering_speed = value; }
    public Rigidbody2D RigidbodyCar { get => rigidbodyCar; set => rigidbodyCar = value; }
    public bool IsCrashed { get => isCrashed; set => isCrashed = value; }
    public bool IsDone { get => isDone; set => isDone = value; }


    void Start()
    {
        // Initialization
        rigidbodyCar = GetComponent<Rigidbody2D>();
        snapPosition = this.transform.position;
        snapRotation = this.transform.rotation;
        car_speed = starting_car_speed;
        steering_speed = starting_steering_speed;
        savedPositions = new List<Vector3>();
        savedRotations = new List<Quaternion>();

        // For Pause|UnPause reasons
        originalConstraints = rigidbodyCar.constraints;

    }

    // If car reaches the exit
    public void ReachedExit()
    {
        isDone = true;
    }

    // If car reaches an obstacle
    public void Crashed()
    {
        car_speed = 0f;
        steering_speed = 0f;
        isDone = true;
        isCrashed = true;
    }

    // Self-Explanatory
    public bool IsNPC()
    {
        return isNPC;
    }

    // Self-Explanatory
    public void setNPC(bool npc)
    {
        
        isNPC = npc;
    }

    // Freezes the car
    public void Freeze()
    {
        rigidbodyCar.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
    }

    // Unfreezes the car
    public void UnFreeze()
    {
        rigidbodyCar.constraints = originalConstraints;
    }

    // Starts particle effect
    public void FireExhaust()
    {
        exhaust.Play();
    } 

    // Resets NPC animations
    public void ResetSavedTime()
    {
        savedTime = 0;
    }

    // Resets car to starting values
    public void TurnStartingPosition()
    {
        this.transform.position = snapPosition;
        this.transform.rotation = snapRotation;
        isCrashed = false;
        isDone = false;
        car_speed = starting_car_speed;
        steering_speed = starting_steering_speed;
    }

    // Save actions for NPC Mode
    public void SaveAction(Vector3 pos, Quaternion rot)
    {
        savedPositions.Add(pos);
        savedRotations.Add(rot);
    }

    // For NPC mode
    public Vector3 ReturnPositionAtTime()
    {
        return savedPositions[savedTime];
    }

    // For NPC mode
    public Quaternion ReturnRotationAtTime()
    {

        return savedRotations[savedTime];
    }

    // For NPC mode
    public bool isActionRemain()
    {
        if(savedTime < savedPositions.Count)
        {
            return true;
        }
        return false;
    }

    // For NPC mode
    public void NextAction()
    {
        savedTime += 1;
    }





}
