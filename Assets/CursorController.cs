using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CursorController : MonoBehaviour
{
    public GameObject[] options;
    int cursorPosition;
    public delegate void OnSelection();
    public OnSelection menuSelection;
    public bool activeCursor;
    // Start is called before the first frame update
    void Start()
    {
        cursorPosition = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(activeCursor && Input.GetKeyDown(KeyCode.Space)) MakeSelection();
        if(activeCursor) {
            UpdatePosition();
        }
    
    }

    void UpdatePosition(){
        if(Input.GetKeyDown(KeyCode.UpArrow)) {
            cursorPosition--;
            if(cursorPosition < 0) cursorPosition = options.Length - 1;
            Debug.Log(cursorPosition);
        } else if(Input.GetKeyDown(KeyCode.DownArrow)) {
            cursorPosition++;
            if(cursorPosition >= options.Length) cursorPosition = 0;
        }
        Vector3 newPosition = transform.position;
        newPosition.y = options[cursorPosition].transform.position.y;
        transform.position = newPosition;
    }

    void MakeSelection() {
        activeCursor = false;
        menuSelection();
    }

    public void TurnOnCursor(GameObject[] newOptions) {
        options = newOptions;
        activeCursor = true;
        cursorPosition = 0;
    }
}
