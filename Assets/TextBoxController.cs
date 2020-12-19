using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBoxController : MonoBehaviour
{
    public string[] script;
    public float printSpeed;
    public KeyCode nextKey;
    Text textField;
    Image endStringIcon;

    // Start is called before the first frame update
    void Start()
    {
        textField = GetComponentInChildren<Text>();
        textField.text = "";
        endStringIcon = GetComponentsInChildren<Image>()[1];
        endStringIcon.enabled = false;
        PlayScript(new string[] {"What in tarnation are you sayin dog be serious", "i love huehuehuehuehuehuehuehuehuehuehuehuehue"});
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayScript(string[] theScript) {
        StartCoroutine(PlayThroughScript(theScript));
    }

    IEnumerator PlayThroughScript(string[] script) {
        for(int i = 0; i < script.Length; i++) {
            string nextLine = script[i];
            for(int j = 0; j < nextLine.Length; j++) {
                textField.text += nextLine[j];
                yield return new WaitForSeconds(printSpeed);
            }
            endStringIcon.enabled = true;
            while(!Input.GetKeyDown(nextKey)) yield return null;
            endStringIcon.enabled = false;
            textField.text = "";
        }
    }
}
