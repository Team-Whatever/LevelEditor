using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    }

    public void OnSceneSave()
    {

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
