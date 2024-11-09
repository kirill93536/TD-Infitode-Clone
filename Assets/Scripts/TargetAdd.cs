using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetAdd : MonoBehaviour
{
    GameObject targetObj;

    public GameObject ReturnTarget()
    {
        return targetObj;
    }

    public Transform ReturnTargetTransform()
    {
        return targetObj.transform;
    }

    public TargetAdd(GameObject targetObj)
    {
        this.targetObj = targetObj;
    }
}
