using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SteamBoiler.tPart.ARSteamBoiler
{
    [CreateAssetMenu(fileName = "SteamBoilerScriptable", menuName = "SteamBoiler/SteamBoilerScriptable")]
    public class SteamBoilerScriptable : ScriptableObject
    {
        [Header("Inputs")]
        public SteamBoilerDatabase database = null;

        [Header("Current")]
        [SerializeField]
        string _imageName = string.Empty;
        public string imageName
        {
            get { return _imageName; }
            set { _imageName = value; currentBoiler = database.GetASteamBoiler(_imageName); }
        }

        public ASteamBoiler currentBoiler = null;
    }
}