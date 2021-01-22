using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Changes minimenu's text 
public class change_minimenu_text : MonoBehaviour
{
    public string loose_condition = "Crashed!";
    public string win_condition = "You Win!";
    public string no_level_left = "No level left!";

    // Update is called once per frame
    void Update()
    {
        if (Player.Instance.isLoosed())
        {
            gameObject.GetComponent<Text>().text = loose_condition; // Changes the button text
        }
        else
        {
            if(Player.Instance.isNoLevelLeft())
            {
               gameObject.GetComponent<Text>().text = no_level_left;   // Changes the button text
            }
            else
            {
               gameObject.GetComponent<Text>().text = win_condition;   // Changes the button text
            }
           
        }
    }
}
