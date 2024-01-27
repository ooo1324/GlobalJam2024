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
        [SerializeField] Camera nowCam;
        // Update is called once per frame
        void Update()
        {   
            //어쨌든 마우스 포지션만 얻을 수 있으면 끝난다.
            mousePos = nowCam.ScreenToWorldPoint(Input.mousePosition) - new Vector3(10f, 3f, Input.mousePosition.z); //뒤의 vector는 영점조절
            this.transform.position = mousePos;
        }
    }
}

