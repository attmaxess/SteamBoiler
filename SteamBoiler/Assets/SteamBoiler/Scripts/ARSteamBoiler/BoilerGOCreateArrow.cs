using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoilerGOCreateArrow : MonoBehaviour
{
    public GameObject arrowPrefab;
    Transform inside = null;

    // Use this for initialization
    void Start()
    {
        
    }

    [ContextMenu("AddArrow")]
    public void AddArrow()
    {
        inside = gameObject.transform.Find("Inside");

        if (inside == null)
        {
            Debug.Log("Boiler not have inside !");
            return;
        }

        Transform[] allPart = inside.GetComponentsInChildren<Transform>();

        if (allPart == null)
        {
            Debug.Log("Boiler not have part !");
            return;
        }

        foreach (var part in allPart)
        {
            if (part.GetComponent<IntroSelectable>() != null)
            {
                ReportArrow arrow = Instantiate(arrowPrefab).GetComponent<ReportArrow>();
                arrow.SetupInit(part);
            }
        }
    }

    [Header("ClearArrow")]
    public bool doneClearArrow = true;

    [ContextMenu("ClearArrow")]
    public void ClearArrow()
    {
        StartCoroutine(C_ClearArrow());
    }

    IEnumerator C_ClearArrow()
    {
        doneClearArrow = false;

        Transform[] allInside = inside.GetComponentsInChildren<Transform>();
        foreach (var arrow in allInside)
        {
            if (arrow.name.Equals("Arrow"))
            {
                Destroy(arrow.gameObject);
            }
        }

        doneClearArrow = true;

        yield break;
    }
}
