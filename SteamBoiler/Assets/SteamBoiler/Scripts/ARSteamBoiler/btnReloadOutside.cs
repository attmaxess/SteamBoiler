using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SteamBoiler.tPart.ARSteamBoiler
{
    public class btnReloadOutside : MonoBehaviour
    {        
        [ContextMenu("OnClick")]
        public void OnClick()
        {
            StartCoroutine(C_OnClick());
        }

        IEnumerator C_OnClick()
        {
            BoilerGO boiler = FindObjectOfType<BoilerGO>();
            if (boiler == null) yield break;
            boiler.OuterOn();
            yield break;
        }
    }
}