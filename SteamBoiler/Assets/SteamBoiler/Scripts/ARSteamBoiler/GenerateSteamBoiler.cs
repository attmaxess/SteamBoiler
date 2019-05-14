using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.iOS;

namespace SteamBoiler.tPart.ARSteamBoiler
{
    public class GenerateSteamBoiler : MonoBehaviour
    {        
        public ARReferenceImage referenceImage = null;
        public SteamBoilerScriptable arBoiler = null;
        public LoadScene loadSceneArModel = null;

        private GameObject imageAnchorGO;

        // Use this for initialization
        void Start()
        {
            UnityARSessionNativeInterface.ARImageAnchorAddedEvent += AddImageAnchor;
            UnityARSessionNativeInterface.ARImageAnchorUpdatedEvent += UpdateImageAnchor;
            UnityARSessionNativeInterface.ARImageAnchorRemovedEvent += RemoveImageAnchor;
        }

        void AddImageAnchor(ARImageAnchor arImageAnchor)
        {
            Debug.LogFormat("image anchor added[{0}] : tracked => {1}", arImageAnchor.identifier, arImageAnchor.isTracked);
            if (arImageAnchor.referenceImageName == referenceImage.imageName)
            {
                #region ARKit load image here, but we don't need it
                //Vector3 position = UnityARMatrixOps.GetPosition(arImageAnchor.transform);
                //Quaternion rotation = UnityARMatrixOps.GetRotation(arImageAnchor.transform);

                //imageAnchorGO = Instantiate<GameObject>(prefabToGenerate, position, rotation);
                #endregion

                arBoiler.imageName = arImageAnchor.referenceImageName;
                loadSceneArModel.DoLoadScene();
            }
        }

        void UpdateImageAnchor(ARImageAnchor arImageAnchor)
        {
            Debug.LogFormat("image anchor updated[{0}] : tracked => {1}", arImageAnchor.identifier, arImageAnchor.isTracked);
            if (arImageAnchor.referenceImageName == referenceImage.imageName)
            {
                if (arImageAnchor.isTracked)
                {
                    if (!imageAnchorGO.activeSelf)
                    {
                        imageAnchorGO.SetActive(true);
                    }
                    imageAnchorGO.transform.position = UnityARMatrixOps.GetPosition(arImageAnchor.transform);
                    imageAnchorGO.transform.rotation = UnityARMatrixOps.GetRotation(arImageAnchor.transform);
                }
                else if (imageAnchorGO.activeSelf)
                {
                    imageAnchorGO.SetActive(false);
                }
            }

        }

        void RemoveImageAnchor(ARImageAnchor arImageAnchor)
        {
            Debug.LogFormat("image anchor removed[{0}] : tracked => {1}", arImageAnchor.identifier, arImageAnchor.isTracked);
            if (imageAnchorGO)
            {
                GameObject.Destroy(imageAnchorGO);
            }
        }

        void OnDestroy()
        {
            UnityARSessionNativeInterface.ARImageAnchorAddedEvent -= AddImageAnchor;
            UnityARSessionNativeInterface.ARImageAnchorUpdatedEvent -= UpdateImageAnchor;
            UnityARSessionNativeInterface.ARImageAnchorRemovedEvent -= RemoveImageAnchor;
        }

        [Header("Test Scan With Result")]
        public string imageName = string.Empty;

        //public 
    }
}