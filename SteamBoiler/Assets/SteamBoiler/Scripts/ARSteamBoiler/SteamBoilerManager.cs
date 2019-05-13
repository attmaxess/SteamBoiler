using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SteamBoiler.tPart.ARSteamBoiler
{
    public class SteamBoilerManager : Singleton<SteamBoilerManager>
    {
        [Header("Data")]
        public SteamBoilerScriptable boilerData = null;

        [Header("Steam Room")]
        public CanvasGroupAlphaManager menuRoom = null;

        #region Outside Methods
        public void OnLoadNewImage(string imageName)
        {
            boilerData.imageName = imageName;


        }
        #endregion
    }
}