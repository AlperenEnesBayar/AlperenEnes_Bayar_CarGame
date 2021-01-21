using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// If this GameObject touches the any cars collision, ends game.
public class obstacle_collide : MonoBehaviour
{

    public GameObject explosion;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Cars"))
        {
            collision.GetComponent<Cars>().Crashed();
            // Explosion effect
            GameObject exposion_effect = Instantiate(explosion) as GameObject;
            exposion_effect.transform.position = collision.transform.position;
        }
    }
}
    