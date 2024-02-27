using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LJH{

    public class RenderingScript : MonoBehaviour
    {
        [SerializeField] public List<GameObject> virtuarCameras = new();

        [SerializeField] List<Image> lightImg = new();

        [SerializeField]
        private Color inactiveColor;
        // [SerializeField] List<BoxCollider2D> screenColliders = new();

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1)){
                ChangeCamera(0);
            }
            if(Input.GetKeyDown(KeyCode.Alpha2)){
                ChangeCamera(1);
            }
            if(Input.GetKeyDown(KeyCode.Alpha3)){
                ChangeCamera(2);
            }
            if(Input.GetKeyDown(KeyCode.Alpha4)){
                ChangeCamera(3);
            }

        }

        void ChangeCamera(int idx)
        {
            for (int i = 0; i < virtuarCameras.Count; i++)
            {
                if (virtuarCameras[i].activeSelf)
                    virtuarCameras[i].SetActive(false);
            }

            for (int i = 0; i < lightImg.Count; i++)
            {
                if (lightImg[i].color == Color.green)
                    lightImg[i].color = inactiveColor;
            }

            virtuarCameras[idx].SetActive(true);
            lightImg[idx].color = Color.green;
            EffectManager.Instance.nowCam = virtuarCameras[idx];
        }
    }
}
