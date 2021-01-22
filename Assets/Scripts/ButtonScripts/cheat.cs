using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Cheats for easy inspection
public class cheat : MonoBehaviour
{
    public void unlock_all_levels()
    {
        for (int i = 0; i < Player.Instance.Levels.Count; i++)
        {
            Player.Instance.Levels[i] = true;
        }
    }
}
