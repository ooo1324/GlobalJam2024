using System.Collections;
using System.Collections.Generic;
using LJH;
using UnityEngine;

public class OverCollider : MonoBehaviour
{   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseEnter() {
        print("enter"+this.gameObject.name);

        //Cursor.SetCursor(CursorManager.Instance.cursorIcon[CursorManager.Instance.nowWeponNum],
        //Vector2.zero, CursorMode.Auto);
    }
    private void OnMouseExit() {
        print("Exit" + this.gameObject.name);

        //Cursor.SetCursor(CursorManager.Instance.nomalCursor, Vector2.zero, CursorMode.Auto);
    }
}
