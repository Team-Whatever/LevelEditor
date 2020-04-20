using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEditorMain : Singleton<LevelEditorMain>
{
    GameObject currentEditingObject;
    List<GameObject> objectsInScene = new List<GameObject>();

    GameObject currentXPos, currentYPos, currentZPos;

    public void Start()
    {
        currentXPos = GameObject.Find("PosX");
        currentYPos = GameObject.Find("PosY");
        currentZPos = GameObject.Find("PosZ");
    }

    public void Update()
    {
       
       if (currentEditingObject != null)
       {
           if (Input.GetMouseButtonUp(0))
           {
               Destroy(currentEditingObject.GetComponent<DragObject>());
           }
           currentEditingObject = null;
       }
       else
       {
           if (Input.GetMouseButtonDown(0))
           {
               Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
               RaycastHit hitInfo;
               if (Physics.Raycast(ray, out hitInfo))
               {
                   currentEditingObject = hitInfo.transform.gameObject;
                   currentEditingObject.AddComponent<DragObject>();
                   Debug.Log(hitInfo.transform.gameObject);

                   Debug.Log(currentXPos.transform.childCount);

                   //GameObject xPosString = currentXPos.transform.Find("Text"); 

                   for (int i = 0; i < currentXPos.transform.childCount - 1; i++)
                   {
                        //Debug.Log(currentXPos.transform.GetChild(i).transform.name);

                        Debug.Log(currentXPos.transform.GetChild(i).transform.name);
                       if (currentXPos.transform.GetChild(i).transform.name.ToString() == "Text") {
                           currentXPos.transform.GetChild(i).transform.GetComponent<UnityEngine.UI.InputField>().text = "00";
                           //currentXPos.transform.GetChild(i).transform.GetComponent<Text>().text = "00"; 

                            currentEditingObject.transform.localPosition.x.ToString();
                            Debug.Log("got it"); 

                        
                    }
                   }

                   Debug.Log(currentEditingObject.transform.localPosition.x.ToString());
               }
           }
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

    public void SaveScene()
    {

    }

    public void LoadScene()
    {

    }
}
