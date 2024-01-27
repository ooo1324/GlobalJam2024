using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LJH{

    public class RenderingScript : MonoBehaviour
    {
        [SerializeField] List<GameObject> virtuarCameras = new();
        [SerializeField] List<Animator> camAnimators = new();

        // Update is called once per frame
        void Update()
        {
            if(Input.GetKeyDown(KeyCode.Alpha1)){
                virtuarCameras[0].SetActive(true);
                virtuarCameras[1].SetActive(false);
                virtuarCameras[2].SetActive(false);
                virtuarCameras[3].SetActive(false);
                camAnimators[0].SetBool("Close",false);
                camAnimators[1].SetBool("Close",true);
                camAnimators[2].SetBool("Close",true);
                camAnimators[3].SetBool("Close",true);
            }
            if(Input.GetKeyDown(KeyCode.Alpha2)){
                virtuarCameras[0].SetActive(false);
                virtuarCameras[1].SetActive(true);
                virtuarCameras[2].SetActive(false);
                virtuarCameras[3].SetActive(false);
                camAnimators[0].SetBool("Close",true);
                camAnimators[1].SetBool("Close",false);
                camAnimators[2].SetBool("Close",true);
                camAnimators[3].SetBool("Close",true);
            }
            if(Input.GetKeyDown(KeyCode.Alpha3)){
                virtuarCameras[0].SetActive(false);
                virtuarCameras[1].SetActive(false);
                virtuarCameras[2].SetActive(true);
                virtuarCameras[3].SetActive(false);
                camAnimators[0].SetBool("Close",true);
                camAnimators[1].SetBool("Close",true);
                camAnimators[2].SetBool("Close",false);
                camAnimators[3].SetBool("Close",true);
            }
            if(Input.GetKeyDown(KeyCode.Alpha4)){
                virtuarCameras[0].SetActive(false);
                virtuarCameras[1].SetActive(false);
                virtuarCameras[2].SetActive(false);
                virtuarCameras[3].SetActive(true);
                camAnimators[0].SetBool("Close",true);
                camAnimators[1].SetBool("Close",true);
                camAnimators[2].SetBool("Close",true);
                camAnimators[3].SetBool("Close",false);
            }

        }
    }
}
