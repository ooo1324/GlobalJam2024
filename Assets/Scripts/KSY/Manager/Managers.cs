using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KSY
{
    public class Managers : MonoBehaviour
    {
        #region instance
        private static Managers _instance;

        public static Managers Instance { get { Init(); return _instance; } }
        #endregion

        #region Managers
        private PoolManager _poolManager = new PoolManager();
        private GameManager _gameManager = new GameManager();

        public static PoolManager Pool { get { return Instance._poolManager; } }
        public static GameManager Game { get { return Instance._gameManager; } }
        #endregion

        private static string managersName = "@Managers";

        private void Awake()
        {
            Init();
        }

        static void Init()
        {
            if (_instance == null)
            {
                GameObject managerObj = GameObject.Find(managersName);

                if (managerObj == null)
                {
                    managerObj = new GameObject { name = managersName };
                    managerObj.AddComponent<Managers>();
                }

                DontDestroyOnLoad(managerObj);

                _instance = managerObj.GetComponent<Managers>();

                _instance._poolManager.Init();
            }
        }
    }

}