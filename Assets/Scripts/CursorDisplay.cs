using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorDisplay : MonoBehaviour
{

    public Texture2D cursorTexture;
    public float cursorDist;

    private float cursorSizeX;
    private float cursorSizeY;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        cursorSizeX = Screen.width / 256 * 9;
        cursorSizeY = Screen.height / 256 * 9;
    }

    //void Update()
    //{
    //    Vector2 cursorDir = Vector2.right * Input.GetAxis("RHorizontal") + Vector2.up * -Input.GetAxis("RVertical");

    //}

    void OnGUI()
    {
        Vector2 cursorDir = Vector2.right * Input.GetAxis("RHorizontal") + Vector2.up * -Input.GetAxis("RVertical");
        if (cursorDir.sqrMagnitude > 0.0f)
        {
            GUI.DrawTexture(new Rect(Camera.main.WorldToScreenPoint(transform.position).x + cursorSizeX * cursorDir.x * cursorDist - cursorSizeX / 2, Screen.height - Camera.main.WorldToScreenPoint(transform.position).y - cursorSizeY * cursorDir.y * cursorDist - cursorSizeY / 2, cursorSizeX, cursorSizeY), cursorTexture);
        }
    }
}
