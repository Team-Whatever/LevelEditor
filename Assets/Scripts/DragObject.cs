using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    Vector3 offset;
    float zCoord;
    //private Color startcolor;

    private void OnMouseDown()
    {
        zCoord = Camera.main.WorldToScreenPoint( gameObject.transform.position ).z;
        offset = gameObject.transform.position - GetMouseWorldPos();

        //startcolor = GetComponent<Renderer>().material.color;
        //GetComponent<Renderer>().material.color = Color.yellow;
    }

    //private void OnMouseUp()
    //{
    //    GetComponent<Renderer>().material.color = startcolor;
    //}

    Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = zCoord;
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint( mousePoint );
        //Debug.Log( "mousew world pos = " + mouseWorldPos );
        return mouseWorldPos;
    }

    private void OnMouseDrag()
    {
        transform.position = GetMouseWorldPos() + offset;
        //Debug.Log( "transform pos = " + transform.position );
    }
}
