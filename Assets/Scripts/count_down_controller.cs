using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Starts Countdown Timer in begining of every episode
public class count_down_controller : MonoBehaviour
{
    public int countdownTime;
    private int counter;
    public Text countdownDisplay;
    public game_manager game_Manager;

    IEnumerator CountdownToStart()
    {
        game_Manager.Pause_The_Game();  // Cars cannot move
        while (counter > 0)
        {
            countdownDisplay.text = counter.ToString();
            yield return new WaitForSeconds(1f);  // Wait 1 sc
            counter--;
        }

        countdownDisplay.text = "GO!";
        game_Manager.Resume_The_Game(); // Cars can move

        yield return new WaitForSeconds(1f);  // Wait 1 sc
        countdownDisplay.gameObject.SetActive(false); // Deactivate CDT
    }

    // Starts CDT's Coroutine
    public void StartCountDownTimer()
    {
        counter = countdownTime;
        countdownDisplay.gameObject.SetActive(true); // Activate CDT
        StartCoroutine(CountdownToStart());
    }

}
