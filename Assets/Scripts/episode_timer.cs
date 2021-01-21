using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Collects time information inside episodes
public class episode_timer : MonoBehaviour
{
    private float current_time = 0.0f;
    private bool isRunning = false;

    
    private void Update()
    {
        if(isRunning)
        {
            Tick();
        }
    }

    // Every update is one deltaTime
    void Tick()
    {
        current_time += Time.deltaTime;
    }

    // Self-Explanatory
    public void ResetTimer()
    {
        isRunning = true;
        current_time = 0.0f;
    }

    // Return time string format. (float)1.94385 --> (string)1.94
    public string GetCurrent()
    {
        return current_time.ToString("F2");
    }

    // Self-Explanatory
    public void StopTimer()
    {
        isRunning = false;
    }


}
