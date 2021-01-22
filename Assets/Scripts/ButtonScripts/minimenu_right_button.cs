using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Controls Minimenu's press actions and buttons text's
public class minimenu_right_button : MonoBehaviour
{
    public string loose_condition = "Retry";
    public string win_condition = "Next";

    public Text right_button_text;

    private void Update()
    {
        if (Player.Instance.isLoosed())
        {
            right_button_text.text = loose_condition; // Changes the button text
        }
        else
        {
            right_button_text.text = win_condition;   // Changes the button text
        }
    }

    [System.Obsolete]
    public void ButtonPressed()
    {
        if (Player.Instance.isLoosed()) // Restart the scene
        {
            Application.LoadLevel(Application.loadedLevel);
        }
        else // Next Scene
        {
            if (Player.Instance.current_level < Player.Instance.Levels.Count)
            {
                SceneManager.LoadScene("Level_" + (Player.Instance.current_level + 1).ToString());
            }
            else
            {
                Player.Instance.setNoLevelLeft(true); // No level left
            }
        }
    }
}
