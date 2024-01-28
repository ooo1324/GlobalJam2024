using System.Collections;
using System.Collections.Generic;
using LJH;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace LJH{
    public class GuageScript : MonoBehaviour
    {
        private static GuageScript _instance;

        public static GuageScript Instance{
            get {
                if(_instance == null)
                    _instance = GameObject.FindObjectOfType(typeof(GuageScript)) as GuageScript;
                
                return _instance;
            }
        }
        [SerializeField] Slider wandGuageSlider;
        [SerializeField] GameObject wandCollider;
        public bool effectFlag;

        // Update is called once per frame
        void Update()
        {
            this.transform.localPosition = Camera.main.WorldToScreenPoint(EffectManager.Instance.mousePos) - new Vector3(600f,800f,0);
            if(CursorManager.Instance.nowWeponNum == 1){
                wandGuageSlider.gameObject.SetActive(true);
                if(Input.GetMouseButton(0)){
                    wandGuageSlider.value += 0.1f;
                }
                if(Input.GetMouseButtonUp(0)){
                    //공격모션
                    //클릭을 떼면 게이지가 0으로 
                    if(wandGuageSlider.value == wandGuageSlider.maxValue){
                        //콜라이더 추가.
                        effectFlag = true;
                        wandCollider.SetActive(true);
                        wandCollider.SetActive(false);
                        wandGuageSlider.value = wandGuageSlider.minValue;
                    }else{
                        wandGuageSlider.value = wandGuageSlider.minValue;
                    }
                }
            }
            else{
                wandGuageSlider.gameObject.SetActive(false);
            }
        }
        
    }
}
