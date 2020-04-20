using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEditorMain : Singleton<LevelEditorMain>
{
    GameObject currentEditingObject;
    List<GameObject> objectsInScene = new List<GameObject>();
    public void Update()
    {
        //if( currentEditingObject != null )
        //{
        //    if( Input.GetMouseButtonUp( 0 ) )
        //    {
        //        Destroy( currentEditingObject.GetComponent<DragObject>() );
        //    }
        //    currentEditingObject = null;
        //}
        //else
        //{
        //    if( Input.GetMouseButtonDown( 0 ) )
        //    {
        //        Ray ray = Camera.main.ScreenPointToRay( Input.mousePosition );
        //        RaycastHit hitInfo;
        //        if( Physics.Raycast( ray, out hitInfo ) )
        //        {
        //            currentEditingObject = hitInfo.transform.gameObject;
        //            currentEditingObject.AddComponent<DragObject>();
        //            Debug.Log( hitInfo.transform.gameObject );
        //        }
        //    }
        //}
    }

    public void BeginPrimitiveObject( GameObject primitiveObject )
    {
        if( primitiveObject != null )
        {
            var obj = Instantiate( primitiveObject );
            objectsInScene.Add( obj );
        }
    }

    public void SaveScene()
    {

    }

    public void LoadScene()
    {

    }
}
