using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

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

    public void SaveScene( string filepath )
    {
        string filename = System.IO.Path.GetFileNameWithoutExtension( filepath );

        GameObjectClass root = new GameObjectClass( filename );
        foreach( object o in objectsInScene )
        {
            GameObject go = ( GameObject )o;
            GameObjectClass childGO = new GameObjectClass( go );
            root.children.Add( childGO );
            SaveObject( go, childGO );
        }

        JsonConvert.DefaultSettings = () => new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.All
        };

        JsonConverter[] converters = new JsonConverter[] { new VectorConverter(), new QuaternionConverter(), new Matrix4x4Converter(), new ColorConverter() };
        string jsonText = JsonConvert.SerializeObject( root, Formatting.Indented, converters );
        System.IO.File.WriteAllText( filepath, jsonText );
    }

    static void SaveObject( GameObject go, GameObjectClass parent )
    {
        Component[] comps = go.GetComponents<Component>();
        foreach( var comp in comps )
        {
            ComponentClass childComp = ComponentFactory.CreateComponentClass( comp );
            parent.components.Add( childComp );
        }
        for( var i = 0; i < go.transform.childCount; i++ )
        {
            GameObject child = go.transform.GetChild( i ).transform.gameObject;
            GameObjectClass childGO = new GameObjectClass( child );
            parent.children.Add( childGO );

            SaveObject( child, childGO );
        }
    }

    public void LoadScene( string filepath )
    {

    }
}
