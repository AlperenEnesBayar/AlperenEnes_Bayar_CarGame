using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class game_manager : MonoBehaviour
{

    // Level Design Variables
    [Header("Level Design")]
    [Tooltip("Entrance's, Exit's and Car's lenght must be equal.")]
    [SerializeField]
    GameObject[] Entrences;
    [SerializeField]
    GameObject[] Exits;
    [SerializeField]
    GameObject[] Cars;
    [SerializeField]
    [Tooltip("Focus Camera for Cars")]
    CinemachineVirtualCamera virtualCamera;
    [SerializeField]
    [Tooltip("UI countdowntimer elements")]
    count_down_controller count_Down_Controller;

    // Current Scenario's informations
    int current_scenario = 0;
    GameObject current_entrance;
    GameObject current_exit;
    GameObject current_car;
    Cars current_cars_script;


    void Start()
    {
        // Start's with first scenario
        Start_Scenario();

    }

    void Update()
    {
        // Checks is game ended
        if (current_cars_script.IsDone)
        {
            
            if(current_cars_script.IsCrashed) // If car crashed shows menu
            {
                // Restart the game or go menu

            }
            else // If not then, passes the next scenario
            {
                if (current_scenario < 8) 
                {
                    // Go next scenario
                    Close_Everything();
                    current_scenario += 1;
                    Start_Scenario();
                }
                else
                {
                    Debug.Log("You Win"); 
                }
                
            }
        }
    }

    void Start_Scenario()
    {
        Close_Everything();
        
        current_entrance = Entrences[current_scenario];
        current_exit = Exits[current_scenario];
        current_car = Cars[current_scenario];


        current_entrance.SetActive(true);
        current_exit.SetActive(true);
        
        
        current_car.transform.position = current_entrance.transform.position;
        current_car.SetActive(true);
        current_cars_script = current_car.GetComponent<Cars>();

        virtualCamera.Follow = current_car.transform;
        virtualCamera.LookAt = current_car.transform;

        count_Down_Controller.StartCountDownTimer();
    }

    // Deactivate all Entrances, Exits and Cars
    void Close_Everything()
    {
        foreach (var entrance in Entrences)
        {
            entrance.SetActive(false);
        }

        foreach (var exit in Exits)
        {
            exit.SetActive(false);
        }

        foreach (var car in Cars)
        {
            car.SetActive(false);
        }
    }

    public void Restart_The_Game()
    {
        current_cars_script.Restart();
        current_scenario = 0;
        Start_Scenario();
    }

    public void Pause_The_Game()
    {
        current_cars_script.Freeze();
    }

    public void Resume_The_Game()
    {
        current_cars_script.UnFreeze();
    }
}
