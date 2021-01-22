using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Singleton Player Class
public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    public List<bool> Levels;
    public int current_level = 1;
    
    private bool loose = false;
    private bool running = false;
    private bool no_level_left = false;


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

    // getters setters
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

    public bool isNoLevelLeft()
    {
        return no_level_left;
    }

    public void setNoLevelLeft(bool noLevelLeft)
    {
        no_level_left = noLevelLeft;
    }
}
