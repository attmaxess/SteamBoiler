using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public string sceneName = string.Empty;
    public bool doneLoadScene = false;

    [ContextMenu("DoLoadScene")]
    public void DoLoadScene()
    {
        doneLoadScene = false;
        SceneManager.LoadScene(sceneName);        
    }

    [ContextMenu("DoLoadSceneAddict")]
    public void DoLoadSceneAddict()
    {
        doneLoadScene = false;
        SceneManager.LoadSceneAsync(sceneName);
    }

    public void DoLoadScene(string sceneName)
    {
        this.sceneName = sceneName;
        DoLoadScene();
    }

    public void DoLoadSceneAddict(string sceneName)
    {
        this.sceneName = sceneName;
        DoLoadSceneAddict();
    }
}
