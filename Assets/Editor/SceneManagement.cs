using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor.SceneManagement;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

[ExecuteInEditMode]
public class SceneManagement : MonoBehaviour
{
    static SceneManagement instance;
    public static SceneManagement Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        if( instance != this )
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this);
    }

    public static void SaveScene( string fileName )
    {
        GameObjectClass root = new GameObjectClass(EditorSceneManager.GetActiveScene().name);
        object[] children = EditorSceneManager.GetActiveScene().GetRootGameObjects();
        foreach (object o in children )
        {
            GameObject go = (GameObject)o;
            GameObjectClass childGO = new GameObjectClass(go);
            root.children.Add(childGO);
            SaveObject( go, childGO );
        }

        JsonConvert.DefaultSettings = () => new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.All
        };

        JsonConverter[] converters = new JsonConverter[] { new VectorConverter(), new QuaternionConverter(), new Matrix4x4Converter(), new ColorConverter() };
        string jsonText = JsonConvert.SerializeObject( root, Formatting.Indented, converters );
        System.IO.File.WriteAllText( fileName, jsonText );
    }

    static void SaveObject( GameObject go, GameObjectClass parent )
    {
        Component[] comps = go.GetComponents<Component>();
        foreach ( var comp in comps )
        {
            ComponentClass childComp = ComponentFactory.CreateComponentClass( comp );
            parent.components.Add(childComp);
        }
        for (var i = 0; i < go.transform.childCount; i++)
        {
            GameObject child = go.transform.GetChild(i).transform.gameObject;
            GameObjectClass childGO = new GameObjectClass(child);
            parent.children.Add(childGO);

            SaveObject(child, childGO);
        }
    }

    public static void LoadScene(string fileName)
    {
        
        string jsonText = System.IO.File.ReadAllText( fileName );
        var settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
        GameObjectClass root = JsonConvert.DeserializeObject<GameObjectClass>( jsonText, settings );
        //GameObjectClass root = JsonUtility.FromJson<GameObjectClass>( jsonText );

        if( root != null )
        {
            EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);

            UnityEngine.SceneManagement.Scene activeScene = EditorSceneManager.GetActiveScene();
            activeScene.name = root.Name;

            foreach ( GameObjectClass goc in root.children )
            {
                GameObject go = new GameObject(goc.Name);
                go.transform.localPosition = goc.transformClass.position;
                go.transform.localScale = goc.transformClass.scale;
                go.transform.localRotation = goc.transformClass.rotation;
                
                LoadObject(go, goc);
            }
        }
    }

    static void LoadObject(GameObject go, GameObjectClass parent)
    {
        foreach (var compClass in parent.components)
        {
            go.CreateComponent( compClass );
        }

        foreach (var childClass in parent.children )
        {
            GameObject childGO = new GameObject( childClass.Name );
            childGO.transform.parent = go.transform;
            childGO.transform.localPosition = childClass.transformClass.position;
            childGO.transform.localScale = childClass.transformClass.scale;
            childGO.transform.localRotation = childClass.transformClass.rotation;
            

            LoadObject( childGO, childClass );
        }
    }

}
