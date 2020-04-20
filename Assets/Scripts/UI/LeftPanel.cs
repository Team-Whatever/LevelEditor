using System.Collections;
using System.Collections.Generic;
using System.Windows;
using UnityEngine;
using SFB;


public enum PrimitiveType
{
    Cube,
    Sphere,
    Cylinder,
    Cone,
    Torus
}

public class LeftPanel : MonoBehaviour
{
    public void OnSceneLoad()
    {
        var paths = StandaloneFileBrowser.OpenFilePanel( "Open File", "", "scene", false );
        if( paths.Length > 0 )
            Debug.Log( "load path = " + paths[0] );
    }

    public void OnSceneSave()
    {
        var path = StandaloneFileBrowser.SaveFilePanel( "Save File", "", "noname", "scene" );
        Debug.Log( "save path = " + path );
    }

    public void OnPrimitiveClicked( GameObject buttonObject )
    {
        GameObject primitiveObject = buttonObject.GetComponent<PrimitiveObject>().prefab;
        LevelEditorMain.Instance.BeginPrimitiveObject( primitiveObject );
    }

    public void OnPlaneClicked()
    {

    }
}
