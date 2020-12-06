using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum PlantStages {Seed, Sprout, Full, Flowered, Dead}
public class PlantController : MonoBehaviour
{
    public int cyclesToSprout;
    int waterContent;
    PlantStages currentStage;
    SpriteRenderer plantRenderer;

    // Start is called before the first frame update
    void Start()
    {
        waterContent = 2;
        currentStage = PlantStages.Seed;
        plantRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
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
            UpdateColor();
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
            Debug.Log("plant dead :(");
            Die();
        }
        else if (cyclesToSprout == 0)
        {
            GrowToNextStage();
        }
            UpdateColor();
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
        Debug.Log("Growing!");
        switch(currentStage)
        {
            case PlantStages.Seed:
                currentStage = PlantStages.Sprout;
                cyclesToSprout = 2;
                break;
            case PlantStages.Sprout:
                currentStage = PlantStages.Full;
                cyclesToSprout = 2;
                break;
            case PlantStages.Full:
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
        plantRenderer.sprite = Resources.Load<Sprite>("PlantStages/" + currentStage.ToString());
    }

    void UpdateColor()
    {
        float h, s, v;
        Color.RGBToHSV(plantRenderer.color, out h, out s, out v);
        v = Mathf.Lerp(0f, 1f, waterContent / 5f);
        plantRenderer.color = Color.HSVToRGB(h,s,v);
    }

    void Die()
    {
        currentStage = PlantStages.Dead;
        cyclesToSprout = 10;
    }
}
