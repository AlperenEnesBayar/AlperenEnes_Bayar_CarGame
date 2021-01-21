﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exit_indicator : MonoBehaviour
{
    public game_manager gm;
    public GameObject car;


    
    void Update()
    {
 
        Transform Exit = gm.ReturnExitsTransformByCar(car.name);

        Vector3 direction_vector = Exit.position - transform.position;

        var angle = Mathf.Atan2(direction_vector.y, direction_vector.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
