using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InspectorWindow : MonoBehaviour
{
    public GameObject targetObject;

    public InputField title;
    public InputField posX;
    public InputField posY;
    public InputField posZ;
    public InputField rotX;
    public InputField rotY;
    public InputField rotZ;
    public InputField scaleX;
    public InputField scaleY;
    public InputField scaleZ;

    private void Awake()
    {
        posX.onEndEdit.AddListener( OnPosXChanged );
        posY.onEndEdit.AddListener( OnPosYChanged );
        posZ.onEndEdit.AddListener( OnPosZChanged );

        scaleX.onEndEdit.AddListener( OnScaleXChanged );
        scaleY.onEndEdit.AddListener( OnScaleYChanged );
        scaleZ.onEndEdit.AddListener( OnScaleZChanged );
    }

    public void SetGameObject( GameObject obj )
    {
        targetObject = obj;

    }

    public void UpdateUI()
    {
        if( targetObject != null )
        {
            title.text = targetObject.name;
            posX.text = targetObject.transform.position.x.ToString();
            posY.text = targetObject.transform.position.y.ToString();
            posZ.text = targetObject.transform.position.z.ToString();

            rotX.text = targetObject.transform.eulerAngles.x.ToString();
            rotY.text = targetObject.transform.eulerAngles.y.ToString();
            rotZ.text = targetObject.transform.eulerAngles.z.ToString();

            scaleX.text = targetObject.transform.localScale.x.ToString();
            scaleY.text = targetObject.transform.localScale.y.ToString();
            scaleZ.text = targetObject.transform.localScale.z.ToString();
        }
        else
        {
            title.text = string.Empty;
            posX.text = string.Empty;
            posY.text = string.Empty;
            posZ.text = string.Empty;
            rotX.text = string.Empty;
            rotY.text = string.Empty;
            rotZ.text = string.Empty;
            scaleX.text = string.Empty;
            scaleY.text = string.Empty;
            scaleZ.text = string.Empty; 
        }
    }

    public void OnPosXChanged( string newValue )
    {
        OnPosChanged( 0, newValue );
    }

    public void OnPosYChanged( string newValue )
    {
        OnPosChanged( 1, newValue );
    }

    public void OnPosZChanged( string newValue )
    {
        OnPosChanged( 2, newValue );
    }

    public void OnPosChanged( int axis, string newValue )
    {
        if( targetObject != null )
        {
            float newPos;
            if( float.TryParse( newValue, out newPos ) )
            {
                Vector3 newPosVector = targetObject.transform.localPosition;
                if( axis == 0 )
                    newPosVector.x = newPos;
                else if( axis == 1 )
                    newPosVector.y = newPos;
                else if( axis == 2 )
                    newPosVector.z = newPos;
                targetObject.transform.localPosition = newPosVector;
                UpdateUI();
            }
        }
    }

    public void OnScaleXChanged( string newValue )
    {
        OnScaleChanged( 0, newValue );
    }

    public void OnScaleYChanged( string newValue )
    {
        OnScaleChanged( 1, newValue );
    }

    public void OnScaleZChanged( string newValue )
    {
        OnScaleChanged( 2, newValue );
    }

    public void OnScaleChanged( int axis, string newValue )
    {
        if( targetObject != null )
        {
            float newScale;
            if( float.TryParse( newValue, out newScale ) )
            {
                Vector3 newScaleVector = targetObject.transform.localScale;
                if( axis == 0 )
                    newScaleVector.x = newScale;
                else if( axis == 1 )
                    newScaleVector.y = newScale;
                else if( axis == 2 )
                    newScaleVector.z = newScale;
                targetObject.transform.localScale = newScaleVector;
                UpdateUI();
            }
        }
    }

}
