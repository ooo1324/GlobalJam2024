using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using Unity.VisualScripting;
using UnityEngine;

namespace LJH{
    public class HPBarScript : MonoBehaviour
    {
        [SerializeField] public List<GameObject> hpCell = new();
        [SerializeField] GameObject hpParent;

        private void Start() {
            for(int i =0; i < hpParent.transform.childCount ; i++){
                hpCell.Add(hpParent.transform.GetChild(i).gameObject);
            }
        }
    }
}


/*

    [SerializeField] GameObject m_goPrefab = null;

        [SerializeField] List<Transform> m_objectList = new();
        [SerializeField] List<GameObject> m_hpBarList = new();

        [SerializeField] Camera m_cam = null;
        // Start is called before the first frame update
        void Start()
        {
            m_cam = Camera.main;

            GameObject[] t_objects = GameObject.FindGameObjectsWithTag("Enemy");
            for(int i=0;i<t_objects.Length; i++){
                m_objectList.Add(t_objects[i].transform);
                GameObject t_hpbar = Instantiate(m_goPrefab, t_objects[i].transform.position, Quaternion.identity, transform);
                m_hpBarList.Add(t_hpbar);
            }
        }

        // Update is called once per frame
        void Update()
        {
            for(int i= 0; i< m_objectList.Count;i++){
                m_hpBarList[i].transform.position = m_cam.WorldToScreenPoint(m_objectList[i].position + new Vector3(12.5f,6.5f,0));
            }
        }

*/
