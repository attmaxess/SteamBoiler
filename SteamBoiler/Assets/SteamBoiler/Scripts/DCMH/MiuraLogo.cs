using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiuraLogo : MonoBehaviour
{
    [Header("Debug")]
    public bool isDebug = true;

    [Header("Inputs")]
    public CanvasGroupAlphaManager canvasManager = null;
    public LoadScene loadScene = null;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    [ContextMenu("OnClick")]
    public void OnClick()
    {
        StartCoroutine(C_OnClick());
    }

    IEnumerator C_OnClick()
    {
        if (isDebug) Debug.Log("canvasManager.GoTo1WaitBack0();");
        canvasManager.GoTo1WaitBack0();

        if (isDebug) Debug.Log("yield return new WaitUntil(() => canvasManager.doneC_ToAlPha == true);");
        yield return new WaitUntil(() => canvasManager.doneC_ToAlPha == true);

        if (isDebug) Debug.Log("loadScene.DoLoadSceneAddict();");
        loadScene.DoLoadSceneAddict();

        if (isDebug) Debug.Log("yield return new WaitUntil(() => SceneManager.GetActiveScene().path == loadScene.sceneName);");
        yield return new WaitUntil(() => SceneManager.GetActiveScene().path == loadScene.sceneName);

        if (isDebug) Debug.Log("if (Application.isPlaying) Destroy(this.gameObject);");
        if (Application.isPlaying) Destroy(this.gameObject);

        yield break;
    }

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }
}
