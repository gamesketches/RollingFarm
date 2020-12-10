using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBehavior : MonoBehaviour
{
    public static float dripTime = 1f;
    public static float fallingSpeed = 0.1f;
    float dripTimer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        dripTimer += Time.deltaTime;
        if(dripTimer > dripTime) Destroy(gameObject);
        
    }
}
