using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Singleton Player Class

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    public List<bool> Levels;
    public int current_level = 0;
    
    private bool loose = false;
    private bool running = false;


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

    public bool isLoosed()
    {
        return loose;
    }

    public void SetLoose(bool isLoose)
    {
        loose = isLoose;
    }

    public bool isRunning()
    {
        return running;
    }

    public void SetRunning(bool isRunning)
    {
        running = isRunning;
    }
}
