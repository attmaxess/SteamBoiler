using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SteamBoiler.tPart.ARSteamBoiler
{
    public class btnUnloadOutside : MonoBehaviour
    {
        [Header("OnClick")]
        public ARBoiler arBoiler = null;
        public bool doneOnClick = true;

        [ContextMenu("OnClick")]
        public void OnClick()
        {
            StartCoroutine(C_OnClick());
        }

        IEnumerator C_OnClick()
        {
            doneOnClick = false;

            BoilerGO boiler = FindObjectOfType<BoilerGO>();
            if (boiler == null) yield break;
            boiler.OuterOff();
            boiler.SetInnerClickable(true);
            boiler.GetComponent<BoilerGOCreateArrow>().AddArrow();

            yield return new WaitUntil(() => boiler.doneSetupInside == true);

            arBoiler.btnReloadOutside.gameObject.SetActive(true);
            gameObject.SetActive(false);

            doneOnClick = true;

            yield break;
        }
    }
}