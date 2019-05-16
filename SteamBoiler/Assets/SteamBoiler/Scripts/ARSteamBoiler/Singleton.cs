using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SteamBoiler.tPart.ARSteamBoiler
{
    /// <summary>
    /// Inherit from this base class to create a singleton.
    /// e.g. public class MyClassName : Singleton<MyClassName> {}
    /// </summary>
    public class SingletonDatabaseManager<T> : MonoBehaviour where T : MonoBehaviour
    {
        // Check to see if we're about to be destroyed.        
        private static T m_Instance;
        public bool isFirst = false;

        /// <summary>
        /// Access singleton instance through this propriety.
        /// </summary>
        public static T Instance
        {
            get
            {
                if (m_Instance == null)
                {
                    // Search for existing instance.
                    m_Instance = (T)FindObjectOfType(typeof(T));

                    // Create new instance if one doesn't already exist.
                    if (m_Instance == null)
                    {
                        // Need to create a new GameObject to attach the singleton to.

                        var singletonObject = Instantiate((GameObject)Resources.Load("(DDOL) Database")).gameObject;
                        singletonObject.name = "(DDOL) Database";
                        m_Instance = singletonObject.GetComponent<T>();
                        m_Instance.GetComponent<SingletonDatabaseManager<T>>().isFirst = true;

                        // Make instance persistent.
                        DontDestroyOnLoad(singletonObject);
                    }
                }
                else
                {
                    List<Object> tList = FindObjectsOfType(typeof(T)).ToList();

                    foreach (T t in tList)
                        if (!t.GetComponent<SingletonDatabaseManager<T>>().isFirst)
                            if (Application.isPlaying) Destroy(t.gameObject); else DestroyImmediate(t.gameObject);
                }

                return m_Instance;
            }
        }
    }
}