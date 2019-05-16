using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAndLimitX : MonoBehaviour
{
    [Header("Params")]    
    public float speed = 1f;
    public Vector2 limitX = new Vector2(315, 45);

    public int direction = 1;
    Vector3 axis = Vector3.zero;

    private void Start()
    {
        var cam = Camera.main.transform;
        axis = transform.InverseTransformDirection(cam.transform.up);
        //RotateLimitX();
    }

    [ContextMenu("RotateLimitX")]
    public void RotateLimitX()
    {
        StartCoroutine(C_RotateLimitX());
    }

    IEnumerator C_RotateLimitX()
    {
        while (true)
        {
            if (transform.localRotation.eulerAngles.y > limitX.y && direction == 1) direction = -1; 
            else if (transform.localRotation.eulerAngles.y > limitX.x && direction == -1) direction = 1;

            transform.Rotate(transform.up * direction);
            DebugCurrentRotate();
            yield return new WaitForEndOfFrame();
        }        
    }

    [ContextMenu("StopAllC")]
    public void StopAllC()
    {
        StopAllCoroutines();
    }

    [ContextMenu("DebugCurrentRotate")]
    public void DebugCurrentRotate()
    {
        Debug.Log(transform.localRotation.eulerAngles);
    }
}
