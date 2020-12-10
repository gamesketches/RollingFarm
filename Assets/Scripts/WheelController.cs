using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelController : MonoBehaviour
{
    public float rotationSpeed;
    public float maxRotationSpeed;
    public float movement;
    float inertia;
    public float friction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float rotationAmount = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
        if(Mathf.Abs(rotationAmount) > 0)
        {
            inertia = Mathf.Min(maxRotationSpeed, inertia + rotationAmount);
        }
        else
        {
            inertia = Mathf.Max(0, inertia + rotationAmount);
        }
        transform.Rotate(0, 0, -inertia);
        Vector3 nextWheelPosition = new Vector3(transform.position.x + (inertia * movement), transform.position.y, 0);
        transform.position = nextWheelPosition;
        nextWheelPosition.z = Camera.main.transform.position.z;
        Camera.main.transform.position = nextWheelPosition;
        if (inertia > 0) inertia -= friction;
    }
}
