using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        if(collision.gameObject.tag == "Player")
        {
            waterContent--;
            Debug.Log("Water content: " + waterContent);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
       if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("watering the plant");
            waterContent++;
        }
        if(Input.GetKeyDown(KeyCode.P))
        {
            if(TryToPick())
            {
                GameObject.Find("PlantCounter").GetComponent<Text>().text = "Plants Raised: 1";
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        cyclesToSprout--;
        if(waterContent <= 0)
        {
            Die();
        }
        else if (cyclesToSprout == 0)
        {
            GrowToNextStage();
            UpdateColor();
        }
    }

    bool TryToPick()
    {
        if(currentStage == PlantStages.Flowered)
        {
            return true;
        }
        return false;
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

    void Die()
    {
        currentStage = PlantStages.Dead;
        cyclesToSprout = 10;
    }
}
