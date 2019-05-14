using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SteamBoiler.tPart.ARSteamBoiler
{
    [RequireComponent(typeof(SteamBoilerManager))]
    public class SteamBoilerCreate : MonoBehaviour
    {        
        public string imageName = string.Empty;

        private SteamBoilerManager _manager = null;
        private SteamBoilerManager manager { get { if (_manager == null) _manager = GetComponent<SteamBoilerManager>(); return _manager; } }

        [Header("Create Process")]
        public bool doneCreate = true;

        [ContextMenu("CreateBoiler")]
        public void CreateBoiler()
        {
            CreateBoiler(this.imageName);
        }

        public void CreateBoiler(string imageName)
        {
            this.imageName = imageName;
            StartCoroutine(C_HandleBoiler(imageName));
        }

        IEnumerator C_HandleBoiler(string imageName)
        {
            doneCreate = false;

            manager.DeleteCurrentBoiler();
            yield return new WaitUntil(() => manager.currentBoiler == null);

            if (!string.IsNullOrEmpty(imageName))
            {
                ASteamBoiler boiler = manager.boilerDataBase.GetASteamBoiler(imageName);
                if (boiler != null)
                {
                    manager.currentBoiler = Instantiate(boiler.prefab, Vector3.zero, Quaternion.identity, manager.boilerHolder).transform;
                }
            }

            doneCreate = true;
            yield break;
        }

        [Header("Blue Boiler")]
        public string blueBoiler = "BlueBoiler";

        [ContextMenu("CreateBlueBoiler")]
        public void CreateBlueBoiler()
        {
            CreateBoiler(this.blueBoiler);
        }
    }
}