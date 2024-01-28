using System;
using System.Collections;
using System.Collections.Generic;
using KSY;
using Unity.Collections;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

namespace LJH{
    public class CursorManager : MonoBehaviour
    {
        #region Instance
        private static CursorManager _instance;
        public static CursorManager Instance{
            get{
                if(_instance == null)
                    _instance = FindObjectOfType(typeof(CursorManager)) as CursorManager;

                return _instance;
            }
        }
        #endregion

        public List<Texture2D> cursorIcon = new();
        public List<GameObject> selectImg = new();
        public List<GameObject> lockImg = new();

        public Texture2D nomalCursor;

        public int nowWeponNum = 0;

        [SerializeField] GameObject attackMotionPrefab;
        [SerializeField] Transform attackMotionGroup;
        [SerializeField] Transform attackMotionPosition;
        // Start is called before the first frame update
        void Start()
        {
            Cursor.SetCursor(cursorIcon[0],Vector2.zero, CursorMode.Auto);//게임 시작했을 땐, 커서를 0으로
            LevelSet();
        }

        // Update is called once per frame
        void Update()
        {
            CursorChange();

            if(Input.GetMouseButtonDown(0)){
                GameObject attackMoation = Instantiate(attackMotionPrefab, 
                    new Vector3(EffectManager.Instance.mousePos.x, EffectManager.Instance.mousePos.y - 2f, 0f), 
                    Quaternion.identity, attackMotionGroup);
                switch(nowWeponNum){
                    case 0: //Sword
                        attackMoation.GetComponent<Animator>().SetBool("Sword",true);
                    break;
                    
                    case 1: //wand
                        attackMoation.GetComponent<Animator>().SetBool("Wand",true);
                    break;

                    case 2: //gun
                        attackMoation.GetComponent<Animator>().SetBool("Gun",true);
                    break;
                }
            }
            // if(Input.GetMouseButtonUp(0)){
            //     if(nowWeponNum == 1){
            //         if(GuageScript.Instance.effectFlag){
            //             GameObject attackMoation = Instantiate(attackMotionPrefab, 
            //             new Vector3(EffectManager.Instance.mousePos.x, EffectManager.Instance.mousePos.y - 2f, 0f), 
            //             Quaternion.identity, attackMotionGroup);
                        
            //             GuageScript.Instance.effectFlag = false;
            //         }
                    
            //     }
            // }
            
        }

        void CursorChange()
        {
            if(Input.GetKeyDown(KeyCode.Q)){
                nowWeponNum -= 1;
                if(nowWeponNum < 0) {
                     nowWeponNum = GameManager.Instance.weaponLevel - 1;
                }
                Cursor.SetCursor(cursorIcon[nowWeponNum],Vector2.zero, CursorMode.Auto);
            }
            if(Input.GetKeyDown(KeyCode.E)){
                nowWeponNum += 1;
                if(nowWeponNum > GameManager.Instance.weaponLevel - 1){
                    nowWeponNum = 0;
                }
                Cursor.SetCursor(cursorIcon[nowWeponNum],Vector2.zero, CursorMode.Auto);
            }
            for(int i = 0; i< cursorIcon.Count ;i++){
                if(i == nowWeponNum){
                    selectImg[i].SetActive(true);
                }
                else{
                    selectImg[i].SetActive(false);
                }
            }
            switch(nowWeponNum){
                case 0: //sword 1
                    GameManager.Instance.dmg = 1;
                break;
                case 1: //wand 5
                    GameManager.Instance.dmg = 5;
                break;
                case 2: //gun 3
                    GameManager.Instance.dmg = 3;
                break;
            }
        }

        public void LevelSet(){
            for(int i = 0;i < GameManager.Instance.weaponLevel - 1;i++){
                lockImg[i].SetActive(false);
            }
        }       
        private void OnMouseExit() {
                print("exit");
        }
        void CursorLimit(){
            
        }
    }

}
