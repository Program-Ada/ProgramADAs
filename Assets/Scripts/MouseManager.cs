using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    public Texture2D cursorDefault;
    public Texture2D cursorClick;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    /*void OnMouseDown() {
      Cursor.SetCursor(cursorClick, hotSpot, cursorMode); 
    }

    void OnMouseUp() {
      Cursor.SetCursor(cursorDefault, hotSpot, cursorMode); 
    }*/

    void Update(){
      
      if(Input.GetMouseButtonDown(0)){
        Cursor.SetCursor(cursorClick, hotSpot, cursorMode);  
      }
      if(Input.GetMouseButtonUp(0)){
        Cursor.SetCursor(cursorDefault, hotSpot, cursorMode);  
      }
    }
}
