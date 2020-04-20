using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    Vector3 offset;
    float zCoord;

    private void OnMouseDown()
    {
        zCoord = Camera.main.WorldToScreenPoint( gameObject.transform.position ).z;
        offset = gameObject.transform.position - GetMouseWorldPos();
    }

    Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = zCoord;
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint( mousePoint );
        Debug.Log( "mousew world pos = " + mouseWorldPos );
        return mouseWorldPos;
    }

    private void OnMouseDrag()
    {
        transform.position = GetMouseWorldPos() + offset;
        Debug.Log( "transform pos = " + transform.position );
    }
}
