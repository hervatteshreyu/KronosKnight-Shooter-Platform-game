using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursor : MonoBehaviour
{

    private Vector3 MouseCoords;
    public float MouseSensitivity = 1f;
    private void Start()
    {
        Cursor.visible = false;
    }
    void Update()
    {
        MouseCoords = Input.mousePosition;
        MouseCoords = Camera.main.ScreenToWorldPoint(MouseCoords);
        transform.position = Vector2.Lerp(transform.position, MouseCoords, MouseSensitivity);
    }
}
