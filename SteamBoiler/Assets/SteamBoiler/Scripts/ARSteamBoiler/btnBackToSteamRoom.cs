using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SteamBoiler.tPart.ARSteamBoiler
{
    public class btnBackToSteamRoom : MonoBehaviour
    {
        [Header("Input")]
        public SteamBoilerManager steamManager = null;
        public CanvasGroupAlphaManager logoCanvas = null;
        public CanvasGroupAlphaManager boilerCanvas = null;
        public CanvasGroupAlphaManager arkitCanvas = null;
        public UnityARCameraManager arKitManager = null;

        [ContextMenu("OnClick")]
        public void OnClick()
        {
            StartCoroutine(C_OnClick());
        }

        IEnumerator C_OnClick()
        {
            boilerCanvas.Alpha1();
            arkitCanvas.Alpha0();

            logoCanvas.Alpha1();
            yield return new WaitUntil(() => logoCanvas.doneC_ToAlPha == true);
            arKitManager.OnDestroy();
            steamManager.room.gameObject.SetActive(true);
            logoCanvas.Alpha0();
            yield return new WaitUntil(() => logoCanvas.doneC_ToAlPha == false);

            yield return new WaitUntil(() => boilerCanvas.doneGoToWaitBack == true && arkitCanvas.doneGoToWaitBack == true);

            Camera.main.transform.localPosition = new Vector3(0, 0, -2f);
            Camera.main.transform.localRotation = Quaternion.identity;

            yield break;
        }
    }
}