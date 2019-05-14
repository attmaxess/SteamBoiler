using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SteamBoiler.tPart.ARSteamBoiler
{
    public class btnChangeModel : MonoBehaviour
    {
        [Header("Input")]
        public SteamBoilerDatabase boilerDatabase = null;
        public Transform boilerHolder = null;

        [Header("ClickAtStart")]
        public bool boolClickAtStart = true;

        private void Start()
        {
            if (boolClickAtStart) OnClick();
        }

        [ContextMenu("OnClick")]
        public void OnClick()
        {
            if (boilerDatabase.boilerList.Count == 0) return;

            BoilerGO currentBoiler = FindObjectOfType<BoilerGO>();

            int idCurrent = -1;
            if (currentBoiler != null)
            {
                idCurrent = boilerDatabase.boilerList.FindIndex((x) => x.imageName == currentBoiler.imageName);
                if (Application.isPlaying) Destroy(currentBoiler.gameObject); else DestroyImmediate(currentBoiler.gameObject);
            }
            else
            {
                idCurrent = -1;
            }

            int idNext = idCurrent == boilerDatabase.boilerList.Count - 1 ? 0 : idCurrent + 1;

            BoilerGO newBoiler = Instantiate(boilerDatabase.boilerList[idNext].prefab, Vector3.zero, Quaternion.identity, boilerHolder).GetComponent<BoilerGO>();
            newBoiler.gameObject.AddComponent<RotateAndLimitX>();
        }
    }
}