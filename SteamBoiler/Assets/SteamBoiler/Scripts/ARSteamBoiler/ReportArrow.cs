using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReportArrow : MonoBehaviour
{
    public void SetupInit(Transform parent)
    {
        transform.name = "Arrow";

        transform.parent = parent;

        MeshRenderer mr = parent.GetComponent<MeshRenderer>();
        Vector3 center = mr.bounds.center;
        transform.position = new Vector3(center.x, center.y + mr.bounds.extents.y, center.z);

        transform.localRotation = Quaternion.Euler(180, 90, 0);
        
        transform.localScale = Vector3.one;
    }
}
