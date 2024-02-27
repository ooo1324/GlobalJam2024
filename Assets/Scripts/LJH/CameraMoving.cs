using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LJH{
    public class CameraMoving : MonoBehaviour
    {
        float xPos, yPos;
        [SerializeField] float speed = 30.0f;
        [SerializeField]
        Camera fullCam;

        // Update is called once per frame
        void Update()
        {
            xPos = Input.GetAxisRaw("Horizontal");
            yPos = Input.GetAxisRaw("Vertical");

            if (fullCam != null)
            {
                Vector3 pos = fullCam.WorldToViewportPoint(this.transform.position + new Vector3(xPos, yPos, 0) * Time.deltaTime * speed);

                if (pos.x < 0f) pos.x = 0f; 
                if (pos.x > 1f) pos.x = 1f;
                if (pos.y < 0f) pos.y = 0f; 
                if (pos.y > 1f) pos.y = 1f;
             
                transform.position = fullCam.ViewportToWorldPoint(pos);
            }
        }
    }
}

