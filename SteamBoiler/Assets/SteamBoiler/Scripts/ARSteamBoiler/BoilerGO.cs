using Lean.Touch;
using SteamBoiler.tPart.ARSteamBoiler;
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

    IEnumerator Start()
    {
        OuterOn();

        SetupInside();
        yield return new WaitUntil(() => doneSetupInside == true);

        SetInnerClickable(false);

        yield break;
    }

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

    [Header("Inside")]
    public bool doneSetupInside = true;
    Transform inside = null;

    public void SetupInside()
    {
        StartCoroutine(C_SetupInside());
    }

    IEnumerator C_SetupInside()
    {
        doneSetupInside = false;

        inside = gameObject.transform.Find("Inside");

        if (inside == null)
        {
            Debug.Log("Boiler not have inside !");
            doneSetupInside = true;
            yield break;
        }

        Transform[] allPart = inside.GetComponentsInChildren<Transform>();

        if (allPart == null)
        {
            Debug.Log("Boiler not have part !");
            doneSetupInside = true;
            yield break;
        }

        foreach (var part in allPart)
        {
            if (part.transform != inside)
            {
                part.gameObject.AddComponent<LeanSelectable>();
                yield return new WaitUntil(() => part.gameObject.GetComponent<LeanSelectable>() != null);

                LeanSelectable selectable = part.gameObject.GetComponent<LeanSelectable>();

                yield return new WaitUntil(() => DatabaseManager.Instance != null);
                BoilerPart boilerPart = DatabaseManager.Instance.scriptCurrentBoiler.currentBoiler.GetBoilerPart(part.name);
                if (boilerPart != null) selectable.enabled = boilerPart.isClickable;

                part.gameObject.AddComponent<LeanSelectableRendererColor>();
                yield return new WaitUntil(() => part.gameObject.GetComponent<LeanSelectableRendererColor>() != null);

                part.gameObject.AddComponent<IntroSelectable>();
                yield return new WaitUntil(() => part.gameObject.GetComponent<IntroSelectable>() != null);

                part.gameObject.AddComponent<ShowIntroPopupAfterClick>();
                yield return new WaitUntil(() => part.gameObject.GetComponent<ShowIntroPopupAfterClick>() != null);
            }
        }

        doneSetupInside = true;

        yield break;
    }

    public void SetInnerClickable(bool Set)
    {
        StartCoroutine(C_SetInnerClickable(Set));
    }

    IEnumerator C_SetInnerClickable(bool Set)
    {
        Transform[] allPart = inside.GetComponentsInChildren<Transform>();

        foreach (var part in allPart)
        {
            LeanSelectable select = part.GetComponent<LeanSelectable>();            
            if (select != null)
            {
                yield return new WaitUntil(() => DatabaseManager.Instance != null);
                BoilerPart boilerPart = DatabaseManager.Instance.scriptCurrentBoiler.currentBoiler.GetBoilerPart(part.name);
                if (boilerPart != null) select.enabled = boilerPart.isClickable ? Set : false;
            }
        }
    }
}
