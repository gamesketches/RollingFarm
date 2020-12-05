using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelController : MonoBehaviour
{
    public float rotationSpeed;
    public float maxSpeed;
    float inertia;
    public float friction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float rotationAmount = Input.GetAxis("Horizontal") * Time.deltaTime;
        if(rotationAmount > 0)
        {
            inertia = Mathf.Min(maxSpeed, inertia + rotationAmount);
        }
        else
        {
            inertia = Mathf.Max(0, inertia + rotationAmount);
        }
        transform.Rotate(0, 0, inertia);
        if (inertia > 0) inertia -= friction;
    }
}
