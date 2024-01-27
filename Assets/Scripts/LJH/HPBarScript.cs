using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using Unity.VisualScripting;
using UnityEngine;

namespace LJH{
    public class HPBarScript : MonoBehaviour
    {
        [SerializeField] public List<GameObject> hpCell = new();
        [SerializeField] public GameObject hpParent;

        private void Start() {
            try{
                for(int i =0; i < hpParent.transform.childCount ; i++){
                hpCell.Add(hpParent.transform.GetChild(i).gameObject);
                }
            } catch(Exception){
                print("exception");
            }
            
        }

        public GameObject hpPop(){
            GameObject cell = hpCell[0];
            hpCell.RemoveAt(0);
            return cell;
        }
    }
}



