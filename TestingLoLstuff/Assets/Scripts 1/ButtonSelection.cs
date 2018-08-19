using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[ExecuteInEditMode]
public class ButtonSelection : MonoBehaviour {

    public Texture2D cursorBase;
    public Texture2D cursorOnHover;

    private bool isInitialCursorSet = false;

    void Update()
    {
        if (!isInitialCursorSet)
        {
            isInitialCursorSet = true;
            Cursor.SetCursor(cursorBase, Vector2.zero, CursorMode.Auto);
        }
    }

    void OnMouseEnter()
    {
        Cursor.SetCursor(cursorOnHover, Vector2.zero, CursorMode.Auto);
    }

    void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}
