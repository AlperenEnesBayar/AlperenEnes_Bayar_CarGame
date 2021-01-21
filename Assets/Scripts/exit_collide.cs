using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exit_collide : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Cars"))
        {
            collision.GetComponent<Cars>().ReachedExit();
        }
    }
}
