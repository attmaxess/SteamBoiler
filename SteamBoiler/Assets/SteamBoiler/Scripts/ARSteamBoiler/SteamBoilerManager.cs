using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SteamBoiler.tPart.ARSteamBoiler
{
    public class SteamBoilerManager : SingletonDatabaseManager<SteamBoilerManager>
    {
        [Header("Data")]
        public SteamBoilerScriptable boilerData = null;
        public SteamBoilerDatabase boilerDataBase = null;

        [Header("Steam Room Objects")]
        public Transform boilerHolder = null;

        [SerializeField]
        Transform _currentBoiler = null;
        public Transform currentBoiler
        {
            get { return _currentBoiler; }
            set { _currentBoiler = value; HandleNewBoiler(); }
        }

        void HandleNewBoiler()
        {
            if (_currentBoiler != null) btnUnloadOutside.gameObject.SetActive(true);
            else btnUnloadOutside.gameObject.SetActive(false);

            btnReloadOutside.gameObject.SetActive(false);
        }

        public Transform room = null;

        [Header("Steam Room UI")]
        public Button btnUnloadOutside = null;
        public Button btnReloadOutside = null;

        #region Outside Methods
        [ContextMenu("DeleteCurrentBoiler")]
        public void DeleteCurrentBoiler()
        {
            if (currentBoiler != null)
                if (Application.isPlaying) Destroy(currentBoiler.gameObject);
                else DestroyImmediate(currentBoiler.gameObject);
        }
        #endregion
    }
}