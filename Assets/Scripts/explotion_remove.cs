﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Explosion effect removal
public class explotion_remove : MonoBehaviour
{
    
    public void ExplotionRemove()
    {
        Destroy(gameObject); // Destroy the explosion effect (self)
    }
}
