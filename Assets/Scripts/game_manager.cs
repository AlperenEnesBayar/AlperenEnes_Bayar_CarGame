using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// This is the main script that manage game flow.
public class game_manager : MonoBehaviour
{

    // Level Design Variables
    [Header("Level Design")]
    [Tooltip("Entrance's, Exit's and Car's lenght must be equal.")]
    [SerializeField]
    List<GameObject> Entrences;
    [Tooltip("Entrance's, Exit's and Car's lenght must be equal.")]
    [SerializeField]
    List<GameObject> Exits;
    [Tooltip("Entrance's, Exit's and Car's lenght must be equal.")]
    [SerializeField]
    List<GameObject> Cars;
    [SerializeField]
    [Tooltip("Focus Camera for Cars")]
    CinemachineVirtualCamera virtualCamera;
    [SerializeField]
    [Tooltip("UI countdowntimer elements")]
    count_down_controller count_Down_Controller;
    [Tooltip("Counter for Replay")]
    public episode_timer episode_Timer;
    public Animator mini_menu;

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
        if (current_cars_script.IsDone)  // Checks is game ended
        {   
            if(current_cars_script.IsCrashed)  // If car crashed, shows menu
            {
                // Restart the game or go menu
                mini_menu.SetBool("isOpen", true);

            }
            else // If not then, passes the next scenario
            {
                if (current_scenario < 7) 
                {
                    // Passes the car's controls to PC
                    current_cars_script.TurnStartingPosition();
                    current_cars_script.setNPC(true);

                    // Go next scenario
                    current_scenario += 1;
                    Start_Scenario();
                }
                else
                {
                    Player.Instance.Levels[Player.Instance.current_level] = true;
                    Pause_The_Game();
                    Player.Instance.SetLoose(false);
                    mini_menu.SetBool("isOpen", true);
                } 
            }
        }
    }

    void Start_Scenario()
    {
        Close_Everything();  // Restarts Everything

        // Set Player running true
        Player.Instance.SetRunning(true);

        // Inıtilize the current variables
        current_entrance = Entrences[current_scenario];
        current_exit = Exits[current_scenario];
        current_car = Cars[current_scenario];

        // Activates start and end points
        current_entrance.SetActive(true);
        current_exit.SetActive(true);
        
        // Activates the current car and spawn in start point
        current_car.transform.position = current_entrance.transform.position;
        current_car.SetActive(true);
        current_cars_script = current_car.GetComponent<Cars>();

        // Moves the camera to car
        virtualCamera.Follow = current_car.transform;
        virtualCamera.LookAt = current_car.transform;

        // Activates NPC cars
        int it = current_scenario;
        while (it > 0)
        {
            it -= 1;
            Cars[it].transform.position = Entrences[it].transform.position;
            Cars[it].SetActive(true);
            Cars[it].GetComponent<Cars>().ResetSavedTime();
        }

        // Starts countdown timer 
        episode_Timer.ResetTimer();
        count_Down_Controller.StartCountDownTimer();
    }

    // Stop Timer. Deactivate all Entrances, Exits and Cars.
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
            car.GetComponent<Cars>().UnFreeze();
            car.SetActive(false);
        }
       
     
        episode_Timer.StopTimer();
    }

    // Returns coordinates exit by Car Name
    public Transform ReturnExitsTransformByCar(string Car)
    {
        int index = 0;
        foreach (GameObject item in Cars)
        {
            if (item.name == Car)
            {
                return Exits[index].transform;
            }
            index += 1;
        }
        return Exits[0].transform; ;
    }

    // Self-Explanatory
    public bool CheckIsDone()
    {
        return current_cars_script.IsDone;
    }

    // Self-Explanatory
    public void Pause_The_Game()
    {
        foreach (GameObject item in Cars)
        {
            item.GetComponent<Cars>().Freeze();
        }
    }

    // Self-Explanatory
    public void Resume_The_Game()
    {
        foreach (GameObject item in Cars)
        {
            item.GetComponent<Cars>().UnFreeze();
        }
    }
}
