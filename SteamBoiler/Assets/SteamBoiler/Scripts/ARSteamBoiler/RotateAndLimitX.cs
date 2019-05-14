using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAndLimitX : MonoBehaviour
{
    [Header("Params")]
    public bool boolRotate = true;
    public float speed = 1f;
    public Vector2 limitX = Vector2.zero;

    private void Update()
    {
        if (!boolRotate) return;
        var cam = Camera.main.transform;
        var axis = transform.InverseTransformDirection(cam.transform.up);
        transform.rotation *= Quaternion.AngleAxis(speed, axis);
    }
}
