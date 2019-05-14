using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGUITransform : MonoBehaviour
{
    [Header("Debug")]
    public bool boolOnGui = false;

    [Header("Params")]
    public Vector2 guiPos = Vector2.zero;

    private void OnGUI()
    {
        if (!boolOnGui) return;
        GUILayout.Label("P : " + transform.position);
    }
}
