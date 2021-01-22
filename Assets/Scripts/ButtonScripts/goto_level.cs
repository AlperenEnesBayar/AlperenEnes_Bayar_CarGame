using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Changes current scene to selected scene
public class goto_level : MonoBehaviour
{
    public int level = 1; // Selected scene
    public GameObject cross;

    private void Start()
    {
        if (Player.Instance.Levels[level - 1])
        {
            cross.SetActive(false);
        }
    }

    public void goto_this_level()
    {
        if(Player.Instance.Levels[level - 1])
        {
            Player.Instance.current_level = level;
            SceneManager.LoadScene("Level_" + level.ToString());
        }
    }
}
