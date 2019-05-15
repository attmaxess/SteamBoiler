using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SteamBoiler.tPart.ARSteamBoiler
{
    [Serializable]
    public class ASteamBoiler
    {
        public string imageName = string.Empty;
        public GameObject prefab = null;

        public List<BoilerPart> boilerParts = new List<BoilerPart>();
        public BoilerPart GetBoilerPart(string partName) { return boilerParts.Find((x) => x.partName == partName); }


        public ASteamBoiler() { }
    }

    [Serializable]
    public class BoilerPart
    {
        public string partName;
        public string partIntro;
    }

    [CreateAssetMenu(fileName = "SteamBoilerDatabase", menuName = "SteamBoiler/SteamBoilerDatabase")]
    public class SteamBoilerDatabase : ScriptableObject
    {
        [Header("Database")]
        public List<ASteamBoiler> boilerList = new List<ASteamBoiler>();

        public ASteamBoiler GetASteamBoiler(string imageName) { return boilerList.Find((x) => x.imageName == imageName); }
    }
}