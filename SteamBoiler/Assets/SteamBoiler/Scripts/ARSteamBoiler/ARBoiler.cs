using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SteamBoiler.tPart.ARSteamBoiler
{
    public class ARBoiler : MonoBehaviour
    {
        [Header("Inputs")]
        public SteamBoilerDatabase boilerDatabase = null;
        public SteamBoilerScriptable currentARBoiler = null;
        public Transform boilerHolder = null;

        [ContextMenu("Start")]
        public void Start()
        {
            if (string.IsNullOrEmpty(currentARBoiler.imageName)) return;

            if (boilerDatabase.boilerList.Count == 0) return;

            int idBoiler = boilerDatabase.boilerList.FindIndex((x) => x.imageName == currentARBoiler.imageName);
            if (idBoiler == -1) return;

            BoilerGO newBoiler = Instantiate(boilerDatabase.boilerList[idBoiler].prefab, Vector3.zero, Quaternion.identity, boilerHolder).GetComponent<BoilerGO>();
            newBoiler.gameObject.AddComponent<RotateAndLimitX>();
        }
    }
}