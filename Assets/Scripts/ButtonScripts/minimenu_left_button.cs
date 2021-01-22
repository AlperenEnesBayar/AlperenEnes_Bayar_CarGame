using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Controls minimenu's Left Button's action
public class minimenu_left_button : MonoBehaviour
{

    public void goto_mainmenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
