using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace LJH{
    //이펙트매니저는 마우스를 따라다니고, 클릭 시 이팩트 발생하게 해야함.
    public class EffectManager : MonoBehaviour
    {
        #region Instance
        private static EffectManager _instance;

        public static EffectManager Instance{
            get{
                if(_instance == null)
                    _instance = FindObjectOfType(typeof(EffectManager)) as EffectManager;
                
                return _instance;
            }
        }
        #endregion
        
        public Vector3 mousePos;

        [SerializeField]
        public Vector3 mouseOffSet = Vector3.zero;

        // Update is called once per frame
        void Update()
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - new Vector3(mouseOffSet.x, mouseOffSet.y, 0); //뒤의 vector는 영점조절
           
            this.transform.position = mousePos;
        }
    }
}

