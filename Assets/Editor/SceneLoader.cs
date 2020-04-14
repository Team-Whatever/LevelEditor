using System.IO;
using UnityEngine;
using UnityEditor;

public class SceneLoader : MonoBehaviour
{
    [MenuItem("Scene Loader/Load Scene")]
    static void LoadScene()
    {
        string path = EditorUtility.OpenFilePanel("Load a scene", "", "scene");
        if (path.Length != 0)
        {
            Debug.Log("Load file : " + path);
            SceneManagement.LoadScene(path);
        }
    }

    [MenuItem("Scene Loader/Save Scene")]
    static void SaveScene()
    {
        string path = EditorUtility.SaveFilePanel("Save a scene",
            "",
            "noname.scene",
            "scene");
        if (path.Length != 0)
        {
            Debug.Log("Save file : " + path);
            SceneManagement.SaveScene(path);
        }
    }

}
