using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SteamBoiler.tPart.ARSteamBoiler
{
    public class btnReloadOutside : MonoBehaviour
    {
        [Header("Input")]
        public SteamBoilerManager steamManager = null;        

        [ContextMenu("OnClick")]
        public void OnClick()
        {
            StartCoroutine(C_OnClick());
        }

        IEnumerator C_OnClick()
        {
            if (steamManager.currentBoiler != null)
            {
                BoilerGO boiler = steamManager.currentBoiler.GetComponent<BoilerGO>();
                boiler.OuterOn();
            }
            yield break;
        }
    }
}