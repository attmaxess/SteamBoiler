using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SteamBoiler.tPart.ARSteamBoiler;

namespace SteamBoiler.tPart.ARSteamBoiler
{
    public class ChangeAlphaMaterial : MonoBehaviour
    {
        public SteamBoilerManager steamBoilerManager;

        [SerializeField]
        private MeshRenderer currentMeshRenderer = null;

        bool isTransparent = false;

        // Start is called before the first frame update
        void Start()
        {
            if (steamBoilerManager.currentBoiler != null)
            {
                currentMeshRenderer = steamBoilerManager.currentBoiler.Find("Outside/Capsule").GetComponent<MeshRenderer>();
                isTransparent = currentMeshRenderer.material.color.a == 0 ? true : false;
            }
        }

        [ContextMenu("ChangeTransparentBoilerOnClick")]
        public void ChangeTransparentBoilerOnClick()
        {
            if (currentMeshRenderer == null)
            {
                return;
            }

            Color currentColor = currentMeshRenderer.material.color;

            if (isTransparent)
            {
                currentMeshRenderer.material.color =
                    new Color(currentColor.r, currentColor.g, currentColor.b, 1);
            }
            else
            {
                currentMeshRenderer.material.color =
                    new Color(currentColor.r, currentColor.g, currentColor.b, 0);
            }

            isTransparent = !isTransparent;
        }
    }
}
