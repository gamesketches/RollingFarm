using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    GameObject categorySelector;
    GameObject itemSelector;
    GameObject moneyCounter;
    TextBoxController itemCommentary;
    bool categorySelected;
    public string[] seedsForSale;
    public string[] equipmentForSale;
    public GameObject itemPrefab;

    // Start is called before the first frame update
    void Start()
    {
        seedsForSale = new string[] {"tom seed", "dude seed"};
        categorySelector = transform.GetChild(0).gameObject;
        categorySelector.GetComponentInChildren<CursorController>().menuSelection += LoadSeeds;
        itemSelector = transform.GetChild(1).gameObject;
        itemCommentary = transform.GetComponentInChildren<TextBoxController>();
        moneyCounter = transform.GetChild(3).gameObject;
        moneyCounter.GetComponentInChildren<Text>().text = "1000G";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadSeeds() {
        List<GameObject> itemsForSale = new List<GameObject>();
        for(int i = 0; i < seedsForSale.Length; i++) {
           GameObject itemForSale = Instantiate<GameObject>(itemPrefab, itemSelector.transform);
           itemForSale.GetComponent<RectTransform>().anchoredPosition = new Vector2(10 + (210*i), 10);
            itemsForSale.Add(itemForSale);
        }
        itemSelector.GetComponentInChildren<CursorController>().TurnOnCursor(itemsForSale.ToArray());//.options = itemsForSale.ToArray();
    }
}
