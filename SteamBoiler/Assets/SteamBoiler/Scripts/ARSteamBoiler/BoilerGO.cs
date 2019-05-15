using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoilerGO : MonoBehaviour
{
    [Header("Define")]
    public string imageName = string.Empty;

    [Header("Body Parts")]
    public List<Transform> outers = new List<Transform>();
    public List<Transform> inners = new List<Transform>();

    [ContextMenu("OuterToggle")]
    public void OuterToggle()
    {
        if (outers.Count == 0) return;
        SetOuter(!outers[0].gameObject.activeSelf);
    }

    [ContextMenu("OuterOn")]
    public void OuterOn()
    {
        SetOuter(true);
    }

    [ContextMenu("OuterOff")]
    public void OuterOff()
    {
        SetOuter(false);
    }

    void SetOuter(bool Set)
    {
        if (outers.Count == 0) return;

        ChangeMode changeMode = GetComponent<ChangeMode>();

        foreach (Transform o in outers)
        {
            MeshRenderer mr = o.gameObject.GetComponent<MeshRenderer>();
            if (mr != null)
            {
                changeMode.mr = mr;
                Material newMaterial = Set ? changeMode.GetOpaque() : changeMode.GetTransparent();
                mr.material = newMaterial;

                Color currentColor = mr.material.color;

                //mr.material.SetFloat("_Mode", Set ? 0f : 3f);
                mr.material.color =
                    new Color(currentColor.r, currentColor.g, currentColor.b, Set ? 1 : 0);

                //mr.UpdateGIMaterials();
            }            
        }
    }
}
