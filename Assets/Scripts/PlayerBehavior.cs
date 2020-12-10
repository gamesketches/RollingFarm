﻿using System.Collections;
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
            StartCoroutine(SprinkleWater());
        }
        transform.Translate(wheel.position.x - transform.position.x, 0, 0);
    }

    IEnumerator SprinkleWater() {
        GameObject water = Instantiate<GameObject>(waterPrefab);
        water.transform.position = transform.position;
        yield return null;
        /*for(float t = 0; t < 0.5f; t += Time.deltaTime) {
            water.transform.position -= new Vector3(0, 0.01f, 0);
            yield return null;
        }
        Destroy(water);*/
    }

}
