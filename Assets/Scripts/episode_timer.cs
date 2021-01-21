using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void Tick()
    {
        current_time += Time.deltaTime;
    }

    public void ResetTimer()
    {
        isRunning = true;
        current_time = 0.0f;
    }

    public string GetCurrent()
    {
        return current_time.ToString("F2");
    }

    public void StopTimer()
    {
        isRunning = false;
    }


}
