using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KSY
{
    public class GameManager : MonoBehaviour
    {
        #region instance
        private static GameManager _instance;

        public static GameManager Instance {
            get{
                if(_instance == null){
                    _instance = FindObjectOfType(typeof(GameManager)) as GameManager;
                }
                return _instance;
            }
        }
        #endregion

        public int weaponLevel = 1;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}