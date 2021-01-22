using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// If Cars reaches to the this collision, game will continue next episode
public class exit_collide : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Cars"))
        {
            collision.GetComponent<Cars>().ReachedExit();

            Player.Instance.SetRunning(false);
        }
    }
}
