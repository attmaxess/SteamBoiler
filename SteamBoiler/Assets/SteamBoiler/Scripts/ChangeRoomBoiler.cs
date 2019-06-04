using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeRoomBoiler : MonoBehaviour {
    public GameObject OnceThroughBoiler;
    public GameObject FlueBoiler;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    [ContextMenu("ChangeRoom")]
    public void ChangeRoom()
    {
        OnceThroughBoiler.SetActive(!OnceThroughBoiler.activeSelf);
        FlueBoiler.SetActive(!FlueBoiler.activeSelf);
    }
}
