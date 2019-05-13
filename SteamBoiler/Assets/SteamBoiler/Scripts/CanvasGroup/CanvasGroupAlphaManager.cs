using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasGroupAlphaManager : MonoBehaviour
{
    [Header("Inputs")]
    public CanvasGroup canvasGroup = null;

    [Header("Process")]
    public float alphaSpeed = 9f;
    public bool Alpha0AtStart = true;

    private void Start()
    {
        if (Alpha0AtStart)
        {
            InstantAlpha1();
            Alpha0();
        }
    }

    [ContextMenu("Alpha0")]
    public void Alpha0()
    {
        if (Application.isPlaying)
        {
            if (gameObject.activeSelf == true)
            {
                StopAllCoroutines();
                StartCoroutine(C_ToAlPha(0));
            }
            else ToAlPha(0);
        }
        else
        {
            ToAlPha(0);
        }
    }

    [ContextMenu("InstantAlpha0")]
    public void InstantAlpha0()
    {
        ToAlPha(0);
    }

    [ContextMenu("Alpha1")]
    public void Alpha1()
    {
        if (Application.isPlaying)
        {
            if (gameObject.activeSelf == true)
            {
                StopAllCoroutines();
                StartCoroutine(C_ToAlPha(1));
            }
            else ToAlPha(1);
        }
        else
        {
            ToAlPha(1);
        }
    }

    [ContextMenu("InstantAlpha1")]
    public void InstantAlpha1()
    {
        ToAlPha(1);
    }

    void ToAlPha(float a)
    {
        canvasGroup.alpha = a;
        canvasGroup.interactable = a != 0;
    }

    [Header("C_ToAlPha")]
    public bool doneC_ToAlPha = true;
    public float snapDelta = 0.07f;

    public IEnumerator C_ToAlPha(float a)
    {
        doneC_ToAlPha = false;

        while (canvasGroup.alpha != a)
        {
            canvasGroup.alpha = Mathf.Lerp(canvasGroup.alpha, a, alphaSpeed * Time.deltaTime);
            if (Mathf.Abs(canvasGroup.alpha - a) < snapDelta) canvasGroup.alpha = a;
            yield return new WaitForEndOfFrame();
        }

        canvasGroup.interactable = a != 0;

        doneC_ToAlPha = true;
        yield break;
    }

    [ContextMenu("StopAllC_")]
    public void StopAllC_()
    {
        StopAllCoroutines();
    }

    [Header("0 goto/goback 1")]
    public float waitTime = 1f;
    public float waitSpeed = 9f;

    public void GoTo0WaitBack1()
    {
        if (!Application.isPlaying) return;
        if (!gameObject.activeSelf) return;
        StopAllC_();
        ResetDefaut();
        StartCoroutine(C_GoToWaitBack(0, 1));
    }

    [Header("GoToWaitBack")]
    public bool doneGoToWaitBack = true;

    public void GoTo1WaitBack0()
    {
        if (!Application.isPlaying) return;
        if (!gameObject.activeSelf) return;
        StopAllC_();
        ResetDefaut();
        StartCoroutine(C_GoToWaitBack(1, 0));
    }

    IEnumerator C_GoToWaitBack(float to, float back)
    {
        doneGoToWaitBack = false;

        float temWaitSpeed = alphaSpeed;
        alphaSpeed = waitSpeed;

        StartCoroutine(C_ToAlPha(to));
        yield return new WaitUntil(() => doneC_ToAlPha == true);

        yield return new WaitForSeconds(waitTime);

        StartCoroutine(C_ToAlPha(back));
        yield return new WaitUntil(() => doneC_ToAlPha == true);

        alphaSpeed = temWaitSpeed;

        doneGoToWaitBack = true;

        yield break;
    }

    [Header("Default")]
    public float defaultAlphaSpeed = 9f;

    [ContextMenu("ResetDefaut")]
    public void ResetDefaut()
    {
        alphaSpeed = defaultAlphaSpeed;
    }
}
