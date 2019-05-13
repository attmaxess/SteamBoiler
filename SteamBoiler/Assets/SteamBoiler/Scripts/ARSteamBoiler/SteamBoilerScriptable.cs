using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SteamBoiler.tPart.ARSteamBoiler
{
    [CreateAssetMenu(fileName = "SteamBoilerScriptable", menuName = "SteamBoiler/SteamBoilerScriptable")]
    public class SteamBoilerScriptable : ScriptableObject
    {
        [Header("Current")]
        public string imageName = string.Empty;
    }
}