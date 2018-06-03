using cakeslice;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineByGaze : MonoBehaviour {
    void GazeEnterFocus() {
        var outlineComponpent = GetComponent<Outline>();
        if (outlineComponpent != null)
        {
            outlineComponpent.eraseRenderer = false;
        }
        Debug.Log("Entered focus on game object: " + gameObject.transform.parent.name);
    }

    void GazeLeaveFocus()
    {
        var outlineComponpent = GetComponent<Outline>();
        if (outlineComponpent != null)
        {
            outlineComponpent.eraseRenderer = true;
        }
        Debug.Log("Left focus from game object: " + gameObject.transform.parent.name);
    }
}
