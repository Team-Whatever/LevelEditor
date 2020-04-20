using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEditorMain : Singleton<LevelEditorMain>
{
    GameObject currentEditingObject;
    public void Update()
    {
        if( currentEditingObject != null )
        {
            if( Input.GetMouseButton( 0 ) )
            {

            }
            
            //currentEditingObject.transform.position = Camera.main.ScreenToWorldPoint( Input.mousePosition );
        }

        //Vector3 worldPos = Camera.main.ScreenToWorldPoint( Input.mousePosition );
        
        //Ray ray = Camera.main.ScreenPointToRay( Input.mousePosition );
        //Debug.Log( "mouse = " + Input.mousePosition + " world = " + worldPos + ", ray = " + ray );
        //Debug.DrawRay( ray.origin, ray.direction * 10, Color.yellow );

    }

    public void BeginPrimitiveObject( GameObject primitiveObject )
    {
        if( primitiveObject != null )
            currentEditingObject = Instantiate( primitiveObject );
    }
}
