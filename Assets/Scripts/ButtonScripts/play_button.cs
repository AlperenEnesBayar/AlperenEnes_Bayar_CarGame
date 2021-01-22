using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Play button (Inside main menu) press actions
public class play_button : MonoBehaviour
{

    public Animator mainmenu;
    public Animator levels;

    public void goto_levels()
    {
        mainmenu.SetBool("isOpen", false);
        levels.SetBool("isOpen", true);
    }
}
