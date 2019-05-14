using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SteamBoiler.tPart.ARSteamBoiler
{
    public class btnScan : MonoBehaviour
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
            boilerCanvas.Alpha0();
            arkitCanvas.Alpha1();

            logoCanvas.Alpha1();
            yield return new WaitUntil(() => logoCanvas.doneC_ToAlPha == true);            
            arKitManager.Start();
            steamManager.room.gameObject.SetActive(false);
            logoCanvas.Alpha0();
            yield return new WaitUntil(() => logoCanvas.doneC_ToAlPha == false);            

            yield break;
        }
    }
}