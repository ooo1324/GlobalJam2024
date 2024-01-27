using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LJH{

    public class RenderingScript : MonoBehaviour
    {
        [SerializeField] List<GameObject> virtuarCameras = new();

        [SerializeField] List<Image> lightImg = new();
        // [SerializeField] List<BoxCollider2D> screenColliders = new();

        // Update is called once per frame
        void Update()
        {
            if(Input.GetKeyDown(KeyCode.Alpha1)){
                virtuarCameras[0].SetActive(true);
                virtuarCameras[1].SetActive(false);
                virtuarCameras[2].SetActive(false);
                virtuarCameras[3].SetActive(false);

                lightImg[0].color = Color.green;
                lightImg[1].color = Color.red;
                lightImg[2].color = Color.red;
                lightImg[3].color = Color.red;

            }
            if(Input.GetKeyDown(KeyCode.Alpha2)){
                virtuarCameras[0].SetActive(false);
                virtuarCameras[1].SetActive(true);
                virtuarCameras[2].SetActive(false);
                virtuarCameras[3].SetActive(false);

                lightImg[0].color = Color.red;
                lightImg[1].color = Color.green;
                lightImg[2].color = Color.red;
                lightImg[3].color = Color.red;
        
            }
            if(Input.GetKeyDown(KeyCode.Alpha3)){
                virtuarCameras[0].SetActive(false);
                virtuarCameras[1].SetActive(false);
                virtuarCameras[2].SetActive(true);
                virtuarCameras[3].SetActive(false);

                lightImg[0].color = Color.red;
                lightImg[1].color = Color.red;
                lightImg[2].color = Color.green;
                lightImg[3].color = Color.red;
                
            }
            if(Input.GetKeyDown(KeyCode.Alpha4)){
                virtuarCameras[0].SetActive(false);
                virtuarCameras[1].SetActive(false);
                virtuarCameras[2].SetActive(false);
                virtuarCameras[3].SetActive(true);
                
                lightImg[0].color = Color.red;
                lightImg[1].color = Color.red;
                lightImg[2].color = Color.red;
                lightImg[3].color = Color.green;
            }

        }
    }
}
