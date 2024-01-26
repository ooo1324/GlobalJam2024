using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LJH{

    public class RenderingScript : MonoBehaviour
    {
        [SerializeField] RenderTexture mainTexture;
        [SerializeField] Camera cam1, cam2, cam3, cam4;
        
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            if(Input.GetKeyDown(KeyCode.Alpha1)){
                cam1.targetTexture = mainTexture;
                cam2.targetTexture = null;
                cam3.targetTexture = null;
                cam4.targetTexture = null;
            }
            if(Input.GetKeyDown(KeyCode.Alpha2)){
                cam1.targetTexture = null;
                cam2.targetTexture = mainTexture;
                cam3.targetTexture = null;
                cam4.targetTexture = null;
            }
            if(Input.GetKeyDown(KeyCode.Alpha3)){
                cam1.targetTexture = null;
                cam2.targetTexture = null;
                cam3.targetTexture = mainTexture;
                cam4.targetTexture = null;
            }
            if(Input.GetKeyDown(KeyCode.Alpha4)){
                cam1.targetTexture = null;
                cam2.targetTexture = null;
                cam3.targetTexture = null;
                cam4.targetTexture = mainTexture;
            }

        }
    }
}
