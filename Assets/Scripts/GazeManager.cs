using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeManager : MonoBehaviour {
    private static GazeManager instance;
    private GazeManager() { }
    public GazeManager Instance {
        get
        {
            if (instance == null)
            {
                instance = new GazeManager();
            }
            return instance;
        }
    }

    private GameObject focusedObject;
    public GameObject FocusedObject { get { return focusedObject;  } } 



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        var hitInfo = new RaycastHit();
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hitInfo))
        {
            var hitObject = hitInfo.collider.gameObject;
            if (focusedObject == null)
                hitObject.SendMessage("GazeEnterFocus", SendMessageOptions.DontRequireReceiver);
            else if (focusedObject != hitObject)
            {
                focusedObject.SendMessage("GazeLeaveFocus", SendMessageOptions.DontRequireReceiver);
                hitObject.SendMessage("GazeEnterFocus", SendMessageOptions.DontRequireReceiver);
            }


            focusedObject = hitObject;
        }
        else
        {
            if (focusedObject != null)
            {
                focusedObject.SendMessage("GazeLeaveFocus", SendMessageOptions.DontRequireReceiver);
                focusedObject = null;
            }
                
        }
    }
}
