using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.iOS;

namespace SteamBoiler.tPart.ARSteamBoiler
{
    public class GenerateSteamBoilerTest : MonoBehaviour
    {
        [Header("Inputs")]
        public SteamBoilerScriptable arBoiler = null;
        public LoadScene loadSceneArModel = null;

        [Header("Test Scan With Result")]
        public string imageName = string.Empty;

        [ContextMenu("DoneARWithCurrent")]
        public void DoneARWithCurrent()
        {
            arBoiler.imageName = imageName;
            loadSceneArModel.DoLoadScene();
        }
    }
}