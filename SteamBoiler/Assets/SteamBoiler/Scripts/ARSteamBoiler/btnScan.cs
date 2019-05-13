using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SteamBoiler.tPart.ARSteamBoiler
{
    public class btnScan : MonoBehaviour
    {
        [Header("Input")]
        public CanvasGroupAlphaManager boilerCanvas = null;
        public UnityARCameraManager arKitManager = null;

        [ContextMenu("OnClick")]
        public void OnClick()
        {
            StartCoroutine(C_OnClick());
        }

        IEnumerator C_OnClick()
        {
            boilerCanvas.GoTo1WaitBack0();

            yield return new WaitForSeconds(.3f);
            arKitManager.Start();

            yield return new WaitUntil(() => boilerCanvas.doneGoToWaitBack == true);

            yield break;
        }
    }
}