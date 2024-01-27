using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LJH{
    public class CameraMoving : MonoBehaviour
    {
        float xPos, yPos;
        [SerializeField] float speed = 10.0f;
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            xPos = Input.GetAxisRaw("Horizontal");
            yPos = Input.GetAxisRaw("Vertical");

            this.transform.position += new Vector3(xPos,yPos,0) * Time.deltaTime * speed;
        }
    }
}

