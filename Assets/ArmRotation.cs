﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmRotation : MonoBehaviour
{
    public int rotationOffset = 90;
    
    
    void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();

        float rotZ = (float) (Math.Atan2(difference.y, difference.x) * Mathf.Rad2Deg);
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + rotationOffset);

    }
}
