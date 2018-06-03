using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeTriggerPopup : MonoBehaviour {

    [SerializeField]
    public GameObject popup;

    void OnTriggerByGaze()
    {
        if (popup != null)
        {
            popup.SetActive(true);
            //resume train movement
            iTween.Pause();

            //make train color translucent
            MakeTrainSeeThru();
        }
            

        Debug.Log("TRIGGERED BY GAZE");
    }

    private void MakeTrainSeeThru()
    {
        var trainMaterials = GameObject.Find("EDDTrain").GetComponent<MeshRenderer>().materials;
        Color color;
        foreach (var mat in trainMaterials)
        {
            color = mat.color;
            // change alfa for transparency
            color.a = 0.30f;
            mat.color = color;
        }
    }
}
