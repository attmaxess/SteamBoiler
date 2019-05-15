﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.iOS;

namespace SteamBoiler.tPart.ARSteamBoiler
{
    public class GenerateSteamBoiler : MonoBehaviour
    {        
        [Header("Inputs")]
        public ARReferenceImage referenceImage = null;
        public SteamBoilerScriptable arBoiler = null;
        public LoadScene loadSceneArModel = null;

        private GameObject imageAnchorGO;

        // Use this for initialization
        void Start()
        {
            UnityARSessionNativeInterface.ARImageAnchorAddedEvent += AddImageAnchor;            
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

                Debug.Log("Detected : " + arImageAnchor.referenceImageName);
                arBoiler.imageName = arImageAnchor.referenceImageName;
                loadSceneArModel.DoLoadScene();
            }
        }

        #region Don't use update and  remove Image Anchor in AR environtment

        //void UpdateImageAnchor(ARImageAnchor arImageAnchor)
        //{
        //    Debug.LogFormat("image anchor updated[{0}] : tracked => {1}", arImageAnchor.identifier, arImageAnchor.isTracked);
        //    if (arImageAnchor.referenceImageName == referenceImage.imageName)
        //    {
        //        if (arImageAnchor.isTracked)
        //        {
        //            if (!imageAnchorGO.activeSelf)
        //            {
        //                imageAnchorGO.SetActive(true);
        //            }
        //            imageAnchorGO.transform.position = UnityARMatrixOps.GetPosition(arImageAnchor.transform);
        //            imageAnchorGO.transform.rotation = UnityARMatrixOps.GetRotation(arImageAnchor.transform);
        //        }
        //        else if (imageAnchorGO.activeSelf)
        //        {
        //            imageAnchorGO.SetActive(false);
        //        }
        //    }

        //}

        //void RemoveImageAnchor(ARImageAnchor arImageAnchor)
        //{
        //    Debug.LogFormat("image anchor removed[{0}] : tracked => {1}", arImageAnchor.identifier, arImageAnchor.isTracked);
        //    if (imageAnchorGO)
        //    {
        //        GameObject.Destroy(imageAnchorGO);
        //    }
        //}

        #endregion

        void OnDestroy()
        {
            UnityARSessionNativeInterface.ARImageAnchorAddedEvent -= AddImageAnchor;            
        }        
    }
}