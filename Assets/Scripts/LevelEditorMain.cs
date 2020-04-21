using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

public class LevelEditorMain : Singleton<LevelEditorMain>
{
    GameObject currentEditingObject;
    List<GameObject> objectsInScene = new List<GameObject>();
    public GameObject[] primitiveObjects;

    GameObject currentXPos, currentYPos, currentZPos;
    public InspectorWindow inspector;

    public void Start()
    {
        currentXPos = GameObject.Find("PosX");
        currentYPos = GameObject.Find("PosY");
        currentZPos = GameObject.Find("PosZ");
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if( EventSystem.current.currentSelectedGameObject != null || EventSystem.current.IsPointerOverGameObject() )
                return;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                GameObject go = hitInfo.transform.gameObject;
                if( go.tag == "Primitive" )
                {
                    currentEditingObject = go;
                }
                else
                {
                    currentEditingObject = null;
                }
                //Debug.Log(currentXPos.transform.childCount);
                ////GameObject xPosString = currentXPos.transform.Find("Text"); 
                //for (int i = 0; i < currentXPos.transform.childCount - 1; i++)
                //{
                //     //Debug.Log(currentXPos.transform.GetChild(i).transform.name);
                //    Debug.Log(currentXPos.transform.GetChild(i).transform.name);
                //    if (currentXPos.transform.GetChild(i).transform.name.ToString() == "Text") {
                //        currentXPos.transform.GetChild(i).transform.GetComponent<UnityEngine.UI.InputField>().text = "00";
                //        //currentXPos.transform.GetChild(i).transform.GetComponent<Text>().text = "00"; 
                //         currentEditingObject.transform.localPosition.x.ToString();
                //         Debug.Log("got it"); 
                //     }
                //}
                //Debug.Log(currentEditingObject.transform.localPosition.x.ToString());
            }
            else
            {
                currentEditingObject = null;
            }
            inspector.SetGameObject( currentEditingObject );
        }
    }

    public void BeginPrimitiveObject( GameObject primitiveObject )
    {
        if( primitiveObject != null )
        {
            var obj = Instantiate( primitiveObject );
            objectsInScene.Add( obj );
        }
    }

    public void ClearScene()
    {
        foreach( var obj in objectsInScene )
        {
            Destroy( obj );
        }
        objectsInScene.Clear();
    }

    public void SaveScene( string filepath )
    {
        string filename = System.IO.Path.GetFileNameWithoutExtension( filepath );

        GameObjectClass root = new GameObjectClass( filename );
        root.Type = "Scene";
        foreach( var go in objectsInScene )
        {
            GameObjectClass childGO = new GameObjectClass( go );
            root.children.Add( childGO );
            SaveObject( go, childGO );
        }

        JsonConverter[] converters = new JsonConverter[] { new VectorConverter(), new QuaternionConverter(), new Matrix4x4Converter(), new ColorConverter() };
        string jsonText = JsonConvert.SerializeObject( root, Formatting.Indented, converters );
        System.IO.File.WriteAllText( filepath, jsonText );
    }

    void SaveObject( GameObject go, GameObjectClass parent )
    {
        var primitiveObj = go.GetComponent<PrimitiveObject>();
        if( primitiveObj != null )
        {
            parent.Type = primitiveObj.type.ToString();
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
        string jsonText = System.IO.File.ReadAllText( filepath );
        var settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
        GameObjectClass root = JsonConvert.DeserializeObject<GameObjectClass>( jsonText, settings );
        //GameObjectClass root = JsonUtility.FromJson<GameObjectClass>( jsonText );

        if( root != null )
        {
            ClearScene();

            LoadObject( null, root );
        }
    }

    void LoadObject( GameObject parent, GameObjectClass goc )
    {
        foreach( var childClass in goc.children )
        {
            GameObject prefab = GetPrefab( childClass.Type );
            GameObject childGO;
            if( prefab != null )
            {
                childGO = Instantiate( prefab );
            }
            else
            {
                childGO = new GameObject( childClass.Name );
            }

            if( parent != null )
                childGO.transform.parent = parent.transform;
            childGO.transform.localPosition = childClass.transformClass.position;
            childGO.transform.localScale = childClass.transformClass.scale;
            childGO.transform.localRotation = childClass.transformClass.rotation;

            LoadObject( childGO, childClass );
        }
    }

    GameObject GetPrefab( string objType )
    {
        foreach( var po in primitiveObjects )
        {
            if( po.GetComponent<PrimitiveObject>() != null )
            {
                if( po.GetComponent<PrimitiveObject>().type.ToString() == objType )
                {
                    return po;
                }
            }
        }
        return null;
    }
}
