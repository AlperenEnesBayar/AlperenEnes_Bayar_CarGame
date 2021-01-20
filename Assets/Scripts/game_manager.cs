using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game_manager : MonoBehaviour
{
    /*          scenarios
     *          _______
     *    Number   Entrance   Exit  CarColor
     *   ______________________________________
     *     1          1        2     Blue (1)
     *     2          2        3     Purple (2)
     *     3          3        1     Orange (3)
     *     4          5        2     Pink (4)
     *     5          4        5     Red (5)
     *     6          6        4     Yellow (6)
     *     7          1        6     Olive (7)
     *     8          3        6     Green (8)
     */

    [SerializeField]
    GameObject[] Entrences;
    [SerializeField]
    GameObject[] Exits;
    [SerializeField]
    GameObject[] Cars;
    [SerializeField]
    CinemachineVirtualCamera virtualCamera;

    // [scenario][Entrance, Exit, Car]
    int[][] scenarios = new int[][]
    {
        new int[] {1, 2, 1},
        new int[] {2, 3, 2},
        new int[] {3, 1, 3},
        new int[] {5, 2, 4},
        new int[] {4, 5, 5},
        new int[] {6, 4, 6},
        new int[] {1, 6, 7},
        new int[] {3, 6, 8}

    };

    int current_scenario = 0;
    GameObject current_entrance;
    GameObject current_exit;
    GameObject current_car;
    car_movement current_cars_script;


    void Start()
    {
        // scenario-1
        Start_Scenario();

    }


    void Update()
    {
        

        if (current_cars_script.isDone)
        {
            if(current_cars_script.isCrashed)
            {
                // Restart the game or go menu

            }
            else
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
        int entrance_number = scenarios[current_scenario][0] - 1;
        int exit_number = scenarios[current_scenario][1] - 1;
        int car_number = scenarios[current_scenario][2] - 1;

        Close_Everything();
        current_entrance = Entrences[entrance_number];
        current_exit = Exits[exit_number];
        current_car = Cars[car_number];


        current_entrance.SetActive(true);
        current_exit.SetActive(true);
        
        
        current_car.transform.position = current_entrance.transform.position;
        current_car.SetActive(true);
        current_cars_script = current_car.GetComponent<car_movement>();

        virtualCamera.Follow = current_car.transform;
        virtualCamera.LookAt = current_car.transform;
        

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
}
