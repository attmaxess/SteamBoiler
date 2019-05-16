using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SteamBoiler.tPart.ARSteamBoiler
{
    public class ARBoiler : MonoBehaviour
    {
        [Header("Debug")]
        public bool isDebug = true;

        [Header("Inputs")]
        public SteamBoilerDatabase boilerDatabase = null;
        public SteamBoilerScriptable currentARBoiler = null;
        public Transform boilerHolder = null;
        public Button btnUnloadOutside = null;
        public Button btnReloadOutside = null;

        [ContextMenu("Start")]
        public void Start()
        {
            if (string.IsNullOrEmpty(currentARBoiler.imageName)) return;
            if (isDebug) Debug.Log("Loading " + currentARBoiler.imageName);

            if (boilerDatabase.boilerList.Count == 0) return;

            int idBoiler = boilerDatabase.boilerList.FindIndex((x) => x.imageName == currentARBoiler.imageName);
            if (idBoiler == -1) return;

            BoilerGO newBoiler = Instantiate(boilerDatabase.boilerList[idBoiler].prefab, Vector3.zero, Quaternion.identity, boilerHolder).GetComponent<BoilerGO>();            

            btnUnloadOutside.gameObject.SetActive(true);
            btnReloadOutside.gameObject.SetActive(false);
        }
    }
}