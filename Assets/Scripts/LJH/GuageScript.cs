using System.Collections;
using System.Collections.Generic;
using LJH;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace LJH{
    public class GuageScript : MonoBehaviour
    {
        [SerializeField] Slider wandGuageSlider;

        // Update is called once per frame
        void Update()
        {
            this.transform.localPosition = Camera.main.WorldToScreenPoint(EffectManager.Instance.mousePos) - new Vector3(700f,600f,0);
            if(CursorManager.Instance.nowWeponNum == 1){
                wandGuageSlider.gameObject.SetActive(true);
                if(Input.GetMouseButton(0)){
                    wandGuageSlider.value += 0.1f;
                }
                if(Input.GetMouseButtonUp(0)){
                    //공격모션
                }
            }
            else{
                wandGuageSlider.gameObject.SetActive(false);
            }
        }
        
    }
}
