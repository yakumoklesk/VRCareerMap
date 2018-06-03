using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardGroup : MonoBehaviour {
    [SerializeField]
    private Transform _target;

    void LateUpdate()
    {
        //var target = Camera.main.transform.position;

        var childCount = transform.childCount;
        for (var i = 0; i < childCount; i++)
        {
            var currentChild = transform.GetChild(i);
            //_target.position.y = currentChild.position.y;
            var targetPosition = new Vector3(_target.position.x, currentChild.position.y, _target.position.z);
            currentChild.LookAt(targetPosition, Vector3.up);
        }
    }
}
