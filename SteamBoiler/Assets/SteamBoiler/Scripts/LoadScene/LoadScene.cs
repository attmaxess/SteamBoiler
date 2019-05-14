using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public string sceneName = string.Empty;

    [ContextMenu("DoLoadScene")]
    public void DoLoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void DoLoadScene(string sceneName)
    {
        this.sceneName = sceneName;
        DoLoadScene();
    }
}
