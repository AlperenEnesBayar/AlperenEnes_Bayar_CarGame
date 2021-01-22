using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goto_level : MonoBehaviour
{
    public int level = 1;

    public void goto_this_level()
    {
        SceneManager.LoadScene("Level_" + level.ToString());
    }
}
