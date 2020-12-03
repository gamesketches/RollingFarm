using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlantStages {Seed, Sprout, Flowered, Dead}
public class PlantController : MonoBehaviour
{
    public int cyclesToSprout;
    int waterContent;
    PlantStages currentStage;
    SpriteRenderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        waterContent = 1;
        currentStage = PlantStages.Seed;
        renderer = GetComponent<SpriteRenderer>();
        UpdateColor();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger Entered");
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("Player Found");
            cyclesToSprout--;
            if(cyclesToSprout == 0)
            {
                GrowToNextStage();
                UpdateColor();        
            }

        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        
    }

    void GrowToNextStage()
    {
        switch(currentStage)
        {
            case PlantStages.Seed:
                currentStage = PlantStages.Sprout;
                cyclesToSprout = 2;
                break;
            case PlantStages.Sprout:
                currentStage = PlantStages.Flowered;
                cyclesToSprout = 4;
                break;
            case PlantStages.Flowered:
                currentStage = PlantStages.Dead;
                cyclesToSprout = 10;
                break;
            case PlantStages.Dead:
                Destroy(gameObject);
                break;
        }
    }

    void UpdateColor()
    {
        switch(currentStage)
        {
            case PlantStages.Seed:
                renderer.color = Color.black;
                break;
            case PlantStages.Sprout:
                renderer.color = Color.yellow;
                break;
            case PlantStages.Flowered:
                renderer.color = Color.green;
                break;
            case PlantStages.Dead:
                renderer.color = Color.grey;
                break;
        }
    }
}
