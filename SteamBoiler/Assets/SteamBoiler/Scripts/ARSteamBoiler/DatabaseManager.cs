using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SteamBoiler.tPart.ARSteamBoiler
{
    public class DatabaseManager : SingletonDatabaseManager<DatabaseManager>
    {
        [Header("Inputs")]
        public SteamBoilerDatabase scriptDatabase = null;
        public SteamBoilerScriptable scriptCurrentBoiler = null;
    }
}