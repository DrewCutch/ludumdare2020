using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{

    // Start is called before the first frame update

    Vector3 cursorCorrection = new Vector3(0, 0, 0);
    
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        cursorPos -= cursorCorrection;
        transform.position = cursorPos;
    }
}
