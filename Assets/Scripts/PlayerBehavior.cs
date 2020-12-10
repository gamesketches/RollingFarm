using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public GameObject waterPrefab;
    public Transform wheel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) {
            SprinkleWater();
        }
        transform.Translate(wheel.position.x - transform.position.x, 0, 0);
    }

    void SprinkleWater() {
        GameObject water = Instantiate<GameObject>(waterPrefab);
        water.transform.position = transform.position;
    }

}
