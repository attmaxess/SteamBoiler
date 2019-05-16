using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SteamBoiler.tPart.ARSteamBoiler
{
    public class btnReloadOutside : MonoBehaviour
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
            boiler.OuterOn();

            BoilerGOCreateArrow arrow = boiler.GetComponent<BoilerGOCreateArrow>();
            arrow.ClearArrow();
            yield return new WaitUntil(() => arrow.doneClearArrow == true);

            boiler.SetInnerClickable(false);
            yield return new WaitUntil(() => boiler.doneSetupInside == true);

            arBoiler.btnUnloadOutside.gameObject.SetActive(true);
            gameObject.SetActive(false);

            doneOnClick = true;

            yield break;
        }
    }
}