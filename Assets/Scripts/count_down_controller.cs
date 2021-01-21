using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class count_down_controller : MonoBehaviour
{
    public int countdownTime;
    private int counter;
    public Text countdownDisplay;
    public game_manager game_Manager;

    IEnumerator CountdownToStart()
    {
        game_Manager.Pause_The_Game();
        while (counter > 0)
        {
            countdownDisplay.text = counter.ToString();

            yield return new WaitForSeconds(1f);

            counter--;
        }

        countdownDisplay.text = "GO!";
        game_Manager.Resume_The_Game();

        yield return new WaitForSeconds(1f);
        countdownDisplay.gameObject.SetActive(false);
    }

    public void StartCountDownTimer()
    {
        counter = countdownTime;
        countdownDisplay.gameObject.SetActive(true);
        StartCoroutine(CountdownToStart());
    }

}
