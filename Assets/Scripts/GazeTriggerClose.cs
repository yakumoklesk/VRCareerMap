using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeTriggerClose : MonoBehaviour
{
    void OnTriggerByGaze()
    {
        transform.parent.gameObject.SetActive(false);

        //resume train movement
        iTween.Resume();

        //make train color solid
        MakeTrainSolid();

    }

    private void MakeTrainSolid()
    {
        var trainMaterials = GameObject.Find("EDDTrain").GetComponent<MeshRenderer>().materials;
        Color color;
        foreach (var mat in trainMaterials)
        {
            color = mat.color;
            // change alfa for transparency
            color.a = 1.0f;
            mat.color = color;
        }
    }
}