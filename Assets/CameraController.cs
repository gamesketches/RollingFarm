﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject wheel;
    public float xLimit;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 nextPos = wheel.transform.position;
        if(nextPos.x < xLimit && nextPos.x > -xLimit) {
            nextPos.z = transform.position.z;
            transform.position = nextPos;
        }
    }
}
