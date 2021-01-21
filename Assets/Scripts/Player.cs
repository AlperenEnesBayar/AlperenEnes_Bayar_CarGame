using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Singleton Player Class

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    public Cars[] cars;
    public int[] CarMoves;
    public float[] MoveTime;
    public int[] MoveDirection;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Instance will not be destroyed between scenes 
        }
        else
        {
            Destroy(gameObject); // It will save only first instance. 
        }
    }
}
