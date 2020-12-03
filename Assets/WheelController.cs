using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelController : MonoBehaviour
{
    public float rotationSpeed;
    public float maxSpeed;
    float inertia;
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
            Debug.Log("Speeding up " + inertia.ToString());
        }
        else
        {
            inertia = Mathf.Max(0, inertia + rotationAmount);
            Debug.Log("Speeding Down " + inertia.ToString());
        }
        transform.Rotate(0, 0, inertia);
    }
}
